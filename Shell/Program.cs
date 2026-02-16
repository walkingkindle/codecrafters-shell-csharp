using Shell;
using Shell.Application;
using Shell.Application.Handlers;
using Shell.Application.Interpreters;
using Shell.Application.Resolvers;
using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Commands.BuiltIn;
using Shell.Infrastructure;
using Shell.Output;
using System.Runtime.CompilerServices;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.ClearProviders();
builder.Services.AddSingleton<ICommandResolver, CommandResolver>();
builder.Services.AddSingleton<ICommandInterpreter, CommandInterpreter>();
builder.Services.AddSingleton<EnvironmentVariableParser>();
builder.Services.AddTransient<PathReader>();
builder.Services.AddTransient<PathSetter>();


AddBuiltInCommands(builder.Services);

static void AddBuiltInCommands(IServiceCollection services)
{
    services.AddSingleton<IBuiltInCommand, Echo>();
    services.AddSingleton<IBuiltInCommand, Exit>();
    services.AddSingleton<IBuiltInCommand, Shell.Domain.Commands.Type>();
    services.AddSingleton<IBuiltInCommand, Pwd>();
    services.AddSingleton<IBuiltInCommand, Clear>();

    services.AddSingleton<IBuiltInCommand, Cd>();
}

AddHandlers(builder.Services);
builder.Services.AddSingleton<IOutputSink, ConsoleOutputSink>();
builder.Services.AddSingleton<ICommandClassifier, CommandClassifier>();
builder.Services.AddSingleton<BuiltInKnowledgeProvider>();
builder.Services.AddSingleton<Delegator>();
builder.Services.AddTransient<IPermissionService, PermissionPathService>();
builder.Services.AddSingleton<PermissionValidator>();
builder.Services.AddSingleton<IExternalDiscoveryService,ExternalDiscoveryService>();
builder.Services.AddSingleton<ExternalKnowledgeProvider>();
builder.Services.AddSingleton<IShellRunner, ShellRunner>();
builder.Services.AddTransient<EnvironmentVariableParser>();
builder.Services.AddSingleton<ProcessStarter>();


Dictionary<string,string> arguments = ResolveArguments(args);
var host = builder.Build();
var shell = host.Services.GetRequiredService<IShellRunner>();
SetVariables(arguments);

shell.Run();

static void AddHandlers(IServiceCollection services)
{
    services.AddSingleton<ICommandHandler, ExitHandler>();
    services.AddSingleton<ICommandHandler, EchoHandler>();
    services.AddSingleton<ICommandHandler, TypeHandler>();
    services.AddSingleton<ICommandHandler,ExternalExecutionHandler>();
    services.AddSingleton<ICommandHandler, PwdHandler>();
    services.AddSingleton<ICommandHandler, CdHandler>();
    services.AddSingleton<ICommandHandler, ClearHandler>();
    //Register other handlers here yo



    //Not found is the last one.
    services.AddSingleton<ICommandHandler, NotFoundHandler>();
}

static Dictionary<string, string> ResolveArguments(string[] args)
{
    if (args == null)
        return new Dictionary<string,string>();

    if (args.Length > 0)
    {
        var arguments = new Dictionary<string, string>();
        foreach (string argument in args)
        {
            int idx = argument.IndexOf('=');
            if (idx > 0)
                arguments[argument.Substring(0, idx)] = argument.Substring(idx + 1);
        }
        return arguments;
    }

    return new Dictionary<string, string>();
}

static void SetVariables(Dictionary<string, string> arguments)
{
    foreach (var variable in arguments)
    {
        Environment.SetEnvironmentVariable(variable.Key, variable.Value);
    }
}

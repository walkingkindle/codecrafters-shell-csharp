using Shell;
using Shell.Application;
using Shell.Application.Handlers;
using Shell.Application.Interpreters;
using Shell.Application.Resolvers;
using Shell.Domain.Abstracts;
using Shell.Output;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.ClearProviders();
builder.Services.AddSingleton<ICommandResolver, CommandResolver>();
builder.Services.AddSingleton<ICommandInterpreter, CommandInterpreter>();

AddHandlers(builder.Services);
builder.Services.AddSingleton<IOutputSink, ConsoleOutputSink>();
builder.Services.AddSingleton<Delegator>();
builder.Services.AddSingleton<IShellRunner, ShellRunner>();


var host = builder.Build();
var shell = host.Services.GetRequiredService<IShellRunner>();

shell.Run();

static void AddHandlers(IServiceCollection services)
{
    services.AddSingleton<ICommandHandler, ExitHandler>();
    services.AddSingleton<ICommandHandler, EchoHandler>();
    //Register other handlers here yo



    //Not found is the last one.
    services.AddSingleton<ICommandHandler, NotFoundHandler>();
}
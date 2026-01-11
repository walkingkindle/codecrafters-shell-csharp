using Shell;
using Shell.Application.Output;
using Shell.Application.Resolvers;
using Shell.Domain.Abstracts;
using Shell.Output;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<ICommandResolver, CommandResolver>();
builder.Services.AddSingleton<ICommandHandler, NotFoundHandler>();
builder.Services.AddSingleton<IOutputWriter, OutputWriter>();
builder.Services.AddSingleton<Delegator>();

var host = builder.Build();
host.Run();

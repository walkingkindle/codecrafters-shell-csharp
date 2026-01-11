using Shell;
using Shell.Application.Resolvers;
using Shell.Domain.Abstracts;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<ICommandResolver, CommandResolver>();
builder.Services.AddSingleton<ICommandHandler, NotFoundHandler>();
builder.Services.AddSingleton<Delegator>();

var host = builder.Build();
host.Run();

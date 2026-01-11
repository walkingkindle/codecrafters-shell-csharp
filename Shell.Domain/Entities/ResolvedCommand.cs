using Shell.Domain.Abstracts;
using System.Data;
namespace Shell.Domain.Entities;
public sealed record ResolvedCommand(Command command, CommandType type) : CommandResolution;

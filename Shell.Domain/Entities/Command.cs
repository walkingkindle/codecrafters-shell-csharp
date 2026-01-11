namespace Shell.Domain.Entities;    
public sealed record Command(string Name, IReadOnlyList<string> Arguments);

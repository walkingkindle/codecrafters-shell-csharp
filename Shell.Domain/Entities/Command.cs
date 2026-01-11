namespace Shell.Domain.Entities
{

    public sealed record Command
    {
        public string Name { get; set;  }
        public IReadOnlyList<string> Arguments { get; set;  }
        public Command(string name, IReadOnlyList<string> arguments)
        {
            Name = name;
            Arguments = arguments.ToList();
        }


    }
}


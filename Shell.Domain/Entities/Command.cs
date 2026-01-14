namespace Shell.Domain.Entities
{

    public sealed record Command
    {
        public string Input { get; set; }
        public IReadOnlyList<string> Arguments { get; set;  }
        public Command(string input, IReadOnlyList<string> arguments)
        {
            Input = input;
            Arguments = arguments.ToList();
        }


    }
}


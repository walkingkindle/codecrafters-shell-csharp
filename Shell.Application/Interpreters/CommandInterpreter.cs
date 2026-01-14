using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Application.Interpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public Command Interpret(string input)
        {
            var split = input.Split(' ');

            return new Command(split.First(), split.Skip(1).ToList());
        }
    }
}

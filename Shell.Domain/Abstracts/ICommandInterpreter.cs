using Shell.Domain.Entities;

namespace Shell.Domain.Abstracts
{
    public interface ICommandInterpreter
    {
        public Command Interpret(string input); 
    }
}

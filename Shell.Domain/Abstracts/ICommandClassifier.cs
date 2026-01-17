using Shell.Domain.Entities;

namespace Shell.Domain.Abstracts
{
    public interface ICommandClassifier
    {
        public CommandType Classify(string input);
    }
}

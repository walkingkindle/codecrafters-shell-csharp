using Shell.Domain.Abstracts;

namespace Shell.Output
{
    public class ConsoleOutputSink : IOutputSink   
    {
        public void Write(string message) => Console.WriteLine(message);

        public void Clear() => Console.Clear();
    }
}

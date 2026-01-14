namespace Shell.Domain.Abstracts
{
    public class ShellExecutionContext
    {
        private readonly IOutputSink _writer;
        public ShellExecutionContext(IOutputSink writer, bool isRunning)
        {
            _writer = writer;
            IsRunning = true;
        }

        public bool IsRunning { get; private set; }

        public void Stop() => IsRunning = false;

        public void Emit(string outputMessage) => _writer.Write(outputMessage);
   }
}

namespace Shell.Domain.Abstracts
{
    public class ShellExecutionContext
    {
        private readonly IOutputSink _writer;
        public ShellExecutionContext(IOutputSink writer, bool isRunning, string currentWorkingDirectory)
        {
            _writer = writer;
            IsRunning = true;
            CurrentWorkingDirectory = currentWorkingDirectory;
        }

        public bool IsRunning { get; private set; }

        public string CurrentWorkingDirectory { get; private set;  }

        public void Stop() => IsRunning = false;

        public void Emit(string outputMessage) => _writer.Write(outputMessage);

        public void ClearConsole() => _writer.Clear();

        public void ChangeCurrentWorkingDirectory(string directory) => CurrentWorkingDirectory = directory;
   }
}

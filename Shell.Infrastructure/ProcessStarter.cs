using System.Diagnostics;

namespace Shell.Infrastructure
{
    public class ProcessStarter
    {
        public void Start(string fileName, string[] arguments)
        {
            var process = new Process();

            process.StartInfo.FileName = fileName;

            process.StartInfo.Arguments = string.Join(" ", arguments);
            process.StartInfo.UseShellExecute = false;
            process.Start();

            process.WaitForExit();
        }
    }
}

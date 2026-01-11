using Shell.Domain.Abstracts;

namespace Shell.Application.Output
{
    public interface IOutputWriter
    {
        public string WriteOutput(CommandResolution resolution);
    }
}

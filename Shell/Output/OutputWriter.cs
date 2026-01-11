using Shell.Application.Output;
using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Concepts;

namespace Shell.Output
{
    public class OutputWriter : IOutputWriter
    {
        public string WriteOutput(CommandResolution resolution)
        {
            string result = "";
            switch (resolution)
            {
                case BuiltInCommand builtin:
                    break;
                case ExternalCommand external:
                    break;
                case CommandNotFound notFound:
                    result = $"{notFound.CommandName}: command not found";
                    break;
            }

            return result;

        }
    }
}

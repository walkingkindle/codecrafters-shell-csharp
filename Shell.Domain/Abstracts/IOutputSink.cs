namespace Shell.Domain.Abstracts
{
    public interface IOutputSink
    {
        void Write(string value);

        void Clear();
    }
}

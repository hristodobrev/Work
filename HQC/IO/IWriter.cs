namespace HQC.IO
{
    public interface IWriter
    {
        void Write(object text);

        void WriteLine(object text);

        void Write(string text, object[] args);

        void WriteLine(string text, object[] args);
    }
}

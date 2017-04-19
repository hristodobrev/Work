using System;
using System.IO;

class UnmanagedWrapper : IDisposable
{
    public FileStream Stream { get; private set; }

    public UnmanagedWrapper()
    {
        this.Stream = File.Open("temp.dat", FileMode.Create);
    }

    ~UnmanagedWrapper()
    {
        Console.WriteLine("Finalizer was here.");
        this.Dispose(false);
    }

    public void Close()
    {
        this.Dispose();
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (this.Stream != null)
            {
                this.Stream.Close();
            }
        }
    }
}

class ImplementingIDisposable
{
    static void Main()
    {
        string s = string.Empty;
        for (int i = 0; i < 100000; i++)
        {
            s += "x";
        }

        return;
        using (UnmanagedWrapper uw = new UnmanagedWrapper())
        {
            string text = "Blababa";
            byte[] bytes = new byte[text.Length * sizeof(char)];
            System.Buffer.BlockCopy(text.ToCharArray(), 0, bytes, 0, bytes.Length);

            uw.Stream.Write(bytes, 0, bytes.Length);
        }
    }
}
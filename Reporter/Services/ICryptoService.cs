namespace Reporter.Services
{
    public interface ICryptoService
    {
        string GetHash(string text);

        bool ValidateHash(string text, string hash);
    }
}

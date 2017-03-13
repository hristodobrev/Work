namespace HQC.Services
{
    public interface ICryptoService
    {
        string PasswordHash(string password);

        bool ValidatePassword(string password, string hash);
    }
}

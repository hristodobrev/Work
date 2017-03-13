namespace HQC.Models
{
    public interface IUser
    {
        int Id { get; }

        string Username { get; }

        string Password{ get; }
        
        string Email { get; }

        UserRole Role { get; }
    }
}

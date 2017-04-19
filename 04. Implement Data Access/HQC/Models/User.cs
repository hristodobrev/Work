namespace HQC.Models
{
    public class User : IUser
    {
        public User(int id, string username, string password, string email, UserRole role = UserRole.User)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Role = role;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]Username: {1}, Password: {2}, Email: {3}", this.Id, this.Username, this.Password, this.Email);
        }
    }
}

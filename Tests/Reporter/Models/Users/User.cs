namespace Reporter.Models.Users
{
    public class User : IRecord<User>
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return this.Id + ": " + this.Username;
        }
    }
}

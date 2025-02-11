namespace CarWebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(int id, string name, string secondName, string email, string password, string role)
        {
            Id = id;
            Name = name;
            SecondName = secondName;
            Email = email;
            Password = password;
            Role = role;
        }

    }
}

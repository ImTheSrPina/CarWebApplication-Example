using CarWebApplication.Models;

namespace CarWebApplication.Services
{
    public class UsersDataBase
    {
        public static List<User> Users = new List<User>()
        {
            new User(1, "John", "Marston", "johnMars1899@yahoo.com", "EldenRingBestGameEver", "User"),
            new User(2, "Johnny", "Silverhand", "samuraijohnny@gmail.com", "ILOVEARASAKA", "Admin"),
        };

        public static List<User> GetUsers() 
        {
            return Users;
        }

        public static User? Login(Login user)
        {
            User? IsUser = Users.FirstOrDefault(
                element =>  element.Email == user.Email && 
                            element.Password == user.Password);
            return IsUser;
        }
    }
}
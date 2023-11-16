namespace StanceNation_1.Services
{
    public class UserService
    {
      
            public class User
            {
                public string UserName { get; set; }
                public string Password { get; set; }
            }

            private static List<User> _users = new List<User>
        {
            new User { UserName = "user1@stancenation.com", Password = "password1" },
            new User { UserName = "user2@stancenation.com", Password = "password2" },
            // Add more users as needed
        };

            public User GetUser(string userName)
            {
                return _users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }


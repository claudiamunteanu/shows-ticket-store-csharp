using System;

namespace app.model
{
    [Serializable]
    public class User : Entity<long>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return Id + " " + Username + " " + Password;
        }

    }
}

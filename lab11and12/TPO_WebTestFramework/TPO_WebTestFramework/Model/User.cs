using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPO_WebTestFramework.Model
{
    public class User
    {
        public string UserName { get; private set; } = "username";
        public string Password { get; private set; } = "password";

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}

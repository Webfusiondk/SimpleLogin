using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PassSalt { get; set; }

        public User(string username, string password, string salt)
        {
            Username = username;
            Password = password;
            PassSalt = salt;
        }

        public User()
        {

        }
    }
}

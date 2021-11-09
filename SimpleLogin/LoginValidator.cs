using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin
{
    class LoginValidator
    {
        HashUser hu = new HashUser();
        DataAccess da = new DataAccess();
        public string ValidateLogin(string username, string password)
        {
            User temp = da.Login(username);
            string saltPassword = Convert.ToBase64String(hu.HashPasswordWithSalt(Encoding.UTF8.GetBytes(temp.PassSalt),Encoding.UTF8.GetBytes(password)));
            if (temp.Password == saltPassword)
                return "Login Success";
            
            return "Wrong input";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin
{
    class HashUser
    {
        DataAccess DA = new DataAccess();
        //Creates user to the DB
        public void GenerateUser(string username, string password)
        {
            string tempSalt = Convert.ToBase64String(GenerateSalt());
            User user = new User(username, Convert.ToBase64String(HashPasswordWithSalt(Encoding.UTF8.GetBytes(tempSalt),Encoding.UTF8.GetBytes(password))),tempSalt);
            DA.RegisterUser(user);
        }

        //Generate the salt we use to hash password
        public byte[] GenerateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[32];
                rng.GetBytes(data);

                return data;
            };
        }

        //Hash the password and salt with use of combine
        public byte[] HashPasswordWithSalt(byte[] salt, byte[] password)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Combine(password, salt));
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

    }
}

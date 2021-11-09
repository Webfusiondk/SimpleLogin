using System;

namespace SimpleLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            UI();
        }

        //Simpel UI
        static void UI()
        {
            LoginValidator LV = new LoginValidator();
            HashUser hUser = new HashUser();
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Register");
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("Please insert new username:");
                    string loginUsername = Console.ReadLine();
                    Console.WriteLine("Please insert new password");
                    string loginPassword = Console.ReadLine();
                    Console.WriteLine(LV.ValidateLogin(loginUsername, loginPassword));
                    break;
                case "2":
                    Console.WriteLine("Please insert new username:");
                    string registerUsername = Console.ReadLine();
                    Console.WriteLine("Please insert new password");
                    string registerPassword = Console.ReadLine();
                    hUser.GenerateUser(registerUsername, registerPassword);
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
        }
    }
}

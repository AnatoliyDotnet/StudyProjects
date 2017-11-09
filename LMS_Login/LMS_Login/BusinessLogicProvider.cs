using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Login
{
    public static class BusinessLogicProvider
    {
        public static void SendUsersCredential(User user)
        {
            user.Login = LoginCreator.Create(user.FirstName, user.LastName);
            user.Password = PasswordGenerator.GeneratePassword(8);
            EmailSender.SendCredentials(user);
        }

        public static void LoginUser(User user)
        {


        }
    }
}

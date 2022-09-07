using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public bool Register(RegistrationModel registrationModel);

        public string Login(LoginModel loginModel);
    }
}

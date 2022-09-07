using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface IUserRL
    {
        public bool Register(RegistrationModel registrationModel);

        public string Login(LoginModel loginModel);
    }
}

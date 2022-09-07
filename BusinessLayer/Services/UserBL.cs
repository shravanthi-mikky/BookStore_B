using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL iUserRL;
        public UserBL(IUserRL iUserRL)
        {
            this.iUserRL = iUserRL;
        }
        public bool Register(RegistrationModel registrationModel)
        {
            try
            {
                return iUserRL.Register(registrationModel);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Login(LoginModel loginModel)
        {
            try
            {
                return iUserRL.Login(loginModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ForgetPassword(string Email)
        {
            try
            {
                return iUserRL.ForgetPassword(Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ResetPassword(string Email, string newpassword, string confirmpassword)
        {
            try
            {
                return iUserRL.ResetPassword(Email, newpassword, confirmpassword);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

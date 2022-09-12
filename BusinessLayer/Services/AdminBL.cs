using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AdminBL : IAdminBL
    {
        IAminRL iAminRL;
        public AdminBL(IAminRL iAminRL)
        {
            this.iAminRL = iAminRL;
        }

        public string AdminLogin(AdminLoginModel adminModel)
        {
            try
            {
                return iAminRL.AdminLogin(adminModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface IAminRL
    {
        public string AdminLogin(AdminLoginModel adminModel);
    }
}

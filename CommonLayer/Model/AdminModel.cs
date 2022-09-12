using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class AdminModel
    {
        //AdminId, AdminName, AdminEmail,AdminPassword, AdminMobile, Address

        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public long AdminMobile { get; set; }
        public string Address { get; set; }

    }
}

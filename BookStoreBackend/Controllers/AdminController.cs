using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        IAdminBL iAdminBL;
        public AdminController(IAdminBL iAdminBL)
        {
            this.iAdminBL = iAdminBL;
        }
        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(AdminLoginModel adminModel)
        {
            try
            {
                var result = iAdminBL.AdminLogin(adminModel);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Login Successfull", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Login Unsuccessfull" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

    }
}

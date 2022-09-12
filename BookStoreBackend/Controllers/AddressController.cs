using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        IAddressBL iAddressBL;
        public AddressController(IAddressBL iAddressBL)
        {
            this.iAddressBL = iAddressBL;
        }
        [HttpPost("Add")]
        public IActionResult Add_Address(AddressModel address)
        {
            try
            {
                var reg = this.iAddressBL.AddAddress(address);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Address Details Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to add" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut("Update")]
        public IActionResult Update_Address(Address_Model address, int AddressId)
        {
            try
            {
                var reg = this.iAddressBL.UpdateAddress(address);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Address Details Updated Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to Update" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("GetAll")]
        public IActionResult GetUserAddress()
        {
            try
            {
                var reg = this.iAddressBL.GetUserAddress();
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Address Details Fetched Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to fetch" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("GetByUserID")]
        public IActionResult GetUserAddressById(long userid)
        {
            try
            {
                var reg = this.iAddressBL.GetUserAddressById(userid);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Address Details of user", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to fetch" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }

        }
    }
}

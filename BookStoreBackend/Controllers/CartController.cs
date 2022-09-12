﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        ICartBL iCartBL;
        public CartController(ICartBL iCartBL)
        {
            this.iCartBL = iCartBL;
        }

        [HttpPost("Add")]
        public IActionResult AddBooks(CartModel books)
        {
            try
            {
                var reg = iCartBL.Cartc(books);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Cart Details Sucessfull", Response = reg });
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

        [HttpDelete("Delete")]
        public IActionResult DeleteCart(long cartid)
        {
            try
            {
                var reg = iCartBL.DeleteCart(cartid);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Cart Details deleted Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to delete" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut("Update")]
        public IActionResult UpdateCart(long cartid, CartModel cart)
        {
            try
            {
                var reg = iCartBL.UpdateCart(cartid, cart);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Cart Details Updated Sucessfull", Response = reg });
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
        [HttpGet("Get")]
        public IActionResult GetCartDetails(long userid)
        {
            try
            {
                var reg = iCartBL.RetriveCartDetails(userid);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Cart Details ", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to Fetch" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}

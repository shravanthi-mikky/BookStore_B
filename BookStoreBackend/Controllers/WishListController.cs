using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStoreBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL wishBL;
        public WishListController(IWishListBL wishBL)
        {
            this.wishBL = wishBL;
        }

        //[Authorize]
        [HttpPost("AddWishList")]
        public ActionResult AddWishList(WishListModel wishList)
        {
            try
            {
                //var currentUser = HttpContext.User;
                //int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                //long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);

                var list = this.wishBL.AddWishList(wishList);

                if (list != null)
                {
                    return this.Ok(new { success = true, message = "Added to your WishList", data = list });
                }
                return this.BadRequest(new { success = false, message = "Failed to add in WishList", data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Authorize]
        [HttpPost("DeleteWishList")]
        public ActionResult RemoveWishList(WishListModel3 wishListModel3)
        {
            try
            {
                //var currentUser = HttpContext.User;
                //int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var list = this.wishBL.DeleteWishList(wishListModel3);

                if (list != null)
                {
                    return this.Ok(new { success = true, message = "Deleting your WishList", data = list });
                }
                return this.BadRequest(new { success = false, message = "Failed to delete WishList", data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //trial method

        [HttpDelete("DeleteWishList1")]
        public ActionResult RemoveWishList1()
        {
            try
            {
                //var currentUser = HttpContext.User;
                //int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var list = this.wishBL.DeleteWishList1();

                if (list != null)
                {
                    return this.Ok(new { success = true, message = "Deleting your WishList", data = list });
                }
                return this.BadRequest(new { success = false, message = "Failed to delete WishList", data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Authorize]
        [HttpGet("GetWishList")]
        public IActionResult GetWishlist()
        {
            try
            {
                //int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "ID").Value);
                var result = wishBL.GetWishlist();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Wishlist got successfully.", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot get wishlist." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

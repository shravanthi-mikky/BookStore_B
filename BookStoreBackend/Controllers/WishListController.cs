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
        public ActionResult AddWishList(WishListModel wishList, int UserId)
        {
            try
            {
                //var currentUser = HttpContext.User;
                //int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                //long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);

                var list = this.wishBL.AddWishList(wishList, UserId);

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
        [HttpDelete("DeleteWishList")]
        public ActionResult RemoveWishList(int WishListId, int UserId)
        {
            try
            {
                //var currentUser = HttpContext.User;
                //int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var list = this.wishBL.DeleteWishList(WishListId, UserId);

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

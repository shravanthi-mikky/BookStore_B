using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        IOrderBL iOrderBL;
        public OrderController(IOrderBL iOrderBL)
        {
            this.iOrderBL = iOrderBL;
        }

        [HttpPost("Add")]
        public IActionResult AddOrder(OrderModel books)
        {
            try
            {
                var reg = iOrderBL.AddOrder(books);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Order Added Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Order not added" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpGet("Get")]
        public IActionResult GetOrders(long userid)
        {
            try
            {
                var reg = iOrderBL.GetOrderById(userid);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Order Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Order not Found" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpDelete("DeleteOrder")]
        public ActionResult RemoveOrder(int OrderId, int UserId)
        {
            try
            {
                //var currentUser = HttpContext.User;
                //int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var list = iOrderBL.DeleteOrder(OrderId, UserId);

                if (list != null)
                {
                    return this.Ok(new { success = true, message = "Deleting your Order", data = list });
                }
                return this.BadRequest(new { success = false, message = "Failed to delete Order", data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBL iFeedbackBL;
        public FeedbackController(IFeedbackBL iFeedbackBL)
        {
            this.iFeedbackBL = iFeedbackBL;
        }

        [HttpPost("Add")]
        public IActionResult Add_FeedBack(FeedbackModel address)
        {
            try
            {
                var reg = iFeedbackBL.AddFeedback(address);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Feedback added Sucessfull", Response = reg });
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

        [HttpGet("Get")]
        public IActionResult RetrieveFeedBackDetails(int bookid)
        {
            try
            {
                var reg = iFeedbackBL.RetrieveFeedBackDetails(bookid);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Feedback Details", Response = reg });
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

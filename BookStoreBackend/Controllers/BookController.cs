using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IBookBL iBookBL;
        public BookController(IBookBL iBookBL)
        {
            this.iBookBL = iBookBL;
        }
        //[Authorize(Roles = Role.Admin)]
        //[Authorize]
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var result = iBookBL.AddBook(bookModel);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Book Added Successfull", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Adding of Book was Unsuccessfull" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }

        }

        [HttpPut("Update")]
        public IActionResult UpdateBooks(BookModel books, long bookid)
        {
            try
            {
                var reg = this.iBookBL.UpdateBook(books, bookid);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Book Updated Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Book details not updated" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteBooks(long bookid)
        {
            try
            {
                var reg = this.iBookBL.DeleteBook(bookid);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Book Deleted Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to delete" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("Get")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var reg = this.iBookBL.GetAllBooks();
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "All Book Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("GetBookByBookId")]
        public IActionResult RetriveBookDetails(long bookid)
        {
            try
            {
                var reg = this.iBookBL.RetriveBookDetails(bookid);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Book Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

    }
}

using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        IBookRL iBookRL;
        public BookBL(IBookRL iBookRL)
        {
            this.iBookRL = iBookRL;
        }

        public BookModel AddBook(BookModel book)
        {
            try
            {
                return iBookRL.AddBook(book);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BookModel UpdateBook(BookModel book, long bookid)
        {
            try
            {
                return iBookRL.UpdateBook(book, bookid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteBook(long bookid)
        {
            try
            {
                return iBookRL.DeleteBook(bookid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public object RetriveBookDetails(long bookid)
        {
            try
            {
                return iBookRL.RetriveBookDetails(bookid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<BookModel> GetAllBooks()
        {
            try
            {
                return iBookRL.GetAllBooks();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

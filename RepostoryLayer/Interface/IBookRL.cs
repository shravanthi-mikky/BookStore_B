using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface IBookRL
    {
        public BookModel AddBook(BookModel book);
        public BookModel UpdateBook(BookModel book, long bookid);
        public bool DeleteBook(long bookid);
        public object RetriveBookDetails(long bookid);
        public List<BookModel> GetAllBooks();
    }
}

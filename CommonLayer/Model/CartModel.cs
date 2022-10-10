using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class CartModel
    {
        //public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

       // public BookModel bookmodel { get; set; }
    }

    public class CartModel2
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        // public BookModel bookmodel { get; set; }
    }

    public class CartModel3
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public string bookName { get; set; }
        public string authorName { get; set; }

        public int discountPrice { get; set; }
        public int originalPrice { get; set; }
        public string bookImage { get; set; }

        // public BookModel bookmodel { get; set; }
    }
    public class CartModel4
    {
        public int CartId { get; set; }
    }
}

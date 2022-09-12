using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int BookId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        //public BookModel bookModel { get; set; }
    }

    public class Order_Model
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        //public int AddressId { get; set; }
        //public int BookId { get; set; }
        //public int Price { get; set; }
        //public int Quantity { get; set; }
       // public DateTime? OrderDate { get; set; }
        public BookModelForGetOrder bookModel { get; set; }

        // OrderId , OrderDate
        // bookName, authorName, DiscountPrice, OriginalPrice, bookImage 
    }
}

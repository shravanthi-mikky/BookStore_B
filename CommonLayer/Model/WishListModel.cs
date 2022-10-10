using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class WishListModel
    {
        //public int WishListId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }

    public class WishListModel1
    {
        public int WishListId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public string bookName { get; set; }
        public string authorName { get; set; }

        public int discountPrice { get; set; }
        public int originalPrice { get; set; }
        public string bookImage { get; set; }
    }

    public class WishListModel3
    {
        public int WishListId { get; set; }
    }


}

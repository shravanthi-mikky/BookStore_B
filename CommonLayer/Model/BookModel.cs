using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace CommonLayer.Model
{
    public class BookModel
    {
        [JsonIgnore]
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string authorName { get; set; }
        public string rating { get; set; }
        public int totalRating { get; set; }
        public int discountPrice { get; set; }
        public int originalPrice { get; set; }
        public string description { get; set; }
        public string bookImage { get; set; }
        [Range(1, 100000, ErrorMessage = "Book Count must be between 1 to 100000 ")]
        public int BookCount { get; set; }
        /*
        [JsonIgnore]
        [ForeignKey("Users")]
        public long AdminId { get; set; }
        [JsonIgnore]
        public virtual AdminModel Users { get; set; }//allow lazy loading,overide userentity class
        */
    }

    
    public class BookModelForGetOrder
    {
        // bookName, authorName, DiscountPrice, OriginalPrice, bookImage, bookId
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string authorName { get; set; }
        public int discountPrice { get; set; }
        public int originalPrice { get; set; }
        public string bookImage { get; set; }

    }
}

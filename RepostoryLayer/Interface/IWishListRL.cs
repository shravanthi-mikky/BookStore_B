using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface IWishListRL
    {
        public WishListModel AddWishList(WishListModel wish, int UserId);
        public string DeleteWishList(int WishListId, int UserId);
        public IEnumerable<WishListModel> GetWishlist();

    }
}

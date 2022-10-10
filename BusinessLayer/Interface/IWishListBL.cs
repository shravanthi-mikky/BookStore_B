using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        public WishListModel AddWishList(WishListModel wish);
        public string DeleteWishList(WishListModel3 wishListModel3);

        public string DeleteWishList1();
        public IEnumerable<WishListModel1> GetWishlist();

    }
}

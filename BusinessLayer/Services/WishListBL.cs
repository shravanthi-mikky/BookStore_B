using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class WishListBL : IWishListBL
    {
        private readonly IWishListRL wishList;
        public WishListBL(IWishListRL wishList)
        {
            this.wishList = wishList;
        }

        public WishListModel AddWishList(WishListModel wish)
        {
            try
            {
                return this.wishList.AddWishList(wish);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string DeleteWishList(WishListModel3 wishListModel3)
        {
            try
            {
                return this.wishList.DeleteWishList(wishListModel3);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //trial method

        public string DeleteWishList1()
        {
            try
            {
                return this.wishList.DeleteWishList1();
            }
            catch (Exception)
            {throw;}
        }

        public IEnumerable<WishListModel1> GetWishlist()
        {
            try
            {
                return wishList.GetWishlist();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

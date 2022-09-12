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

        public WishListModel AddWishList(WishListModel wish, int UserId)
        {
            try
            {
                return this.wishList.AddWishList(wish, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string DeleteWishList(int WishListId, int UserId)
        {
            try
            {
                return this.wishList.DeleteWishList(WishListId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<WishListModel> GetWishlist()
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

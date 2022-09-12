using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CartBL : ICartBL
    {
        ICartRL iCartRL;
        public CartBL(ICartRL iCartRL)
        {
            this.iCartRL = iCartRL;
        }

        public CartModel Cartc(CartModel cart)
        {
            try
            {
                return iCartRL.Cartc(cart);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteCart(long cartid)
        {
            try
            {
                return iCartRL.DeleteCart(cartid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CartModel UpdateCart(long cartid, CartModel cart)
        {
            try
            {
                return iCartRL.UpdateCart(cartid, cart);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CartModel> RetriveCartDetails(long userid)
        {
            try
            {
                return iCartRL.RetriveCartDetails(userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

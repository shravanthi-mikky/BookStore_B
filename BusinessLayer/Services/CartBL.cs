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
        public bool DeleteCart(CartModel4 cartModel4)
        {
            try
            {
                return iCartRL.DeleteCart(cartModel4);
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

        public List<CartModel2> GetAllCart()
        {
            try
            {
                return iCartRL.GetAllCart();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CartModel3> GetAllCartItems()
        {
            try
            {
                return iCartRL.GetAllCartItems();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

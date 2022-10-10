using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface ICartRL
    {
        public CartModel Cartc(CartModel cart);
        public bool DeleteCart(CartModel4 cartModel4);
        public CartModel UpdateCart(long cartid, CartModel cart);
        public List<CartModel> RetriveCartDetails(long userid);

        public List<CartModel2> GetAllCart();

        public List<CartModel3> GetAllCartItems();
    }
}

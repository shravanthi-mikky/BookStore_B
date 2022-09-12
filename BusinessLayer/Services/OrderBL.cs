using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderBL : IOrderBL
    {
        IOrderRL iOrderRL;
        public OrderBL(IOrderRL iOrderRL)
        {
            this.iOrderRL = iOrderRL;
        }

        public OrderModel AddOrder(OrderModel addorder)
        {
            try
            {
                return this.iOrderRL.AddOrder(addorder);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Order_Model> GetOrderById(long userid)
        {
            try
            {
                return this.iOrderRL.GetOrderById(userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

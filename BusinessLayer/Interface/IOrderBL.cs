using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public OrderModel AddOrder(OrderModel addorder);
        public List<Order_Model> GetOrderById(long userid);
    }
}

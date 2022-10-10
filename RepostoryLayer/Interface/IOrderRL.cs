using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface IOrderRL
    {
        public OrderModel AddOrder(OrderModel addorder);
        public List<Order_Model> GetOrderById(long userid);
        public string DeleteOrder(int OrderId, int UserId);
    }
}

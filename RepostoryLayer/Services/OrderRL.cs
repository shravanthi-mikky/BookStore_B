using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepostoryLayer.Services
{
    public class OrderRL : IOrderRL
    {
        private readonly IConfiguration configuration;
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=BookStore;Integrated Security=True;";
        public OrderRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public OrderModel AddOrder(OrderModel addorder)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("Sp_AddOrder", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@UserId", addorder.UserId);
                    com.Parameters.AddWithValue("@BookId", addorder.BookId);
                    com.Parameters.AddWithValue("@BookQuantity", addorder.Quantity);
                    com.Parameters.AddWithValue("@AddressId", addorder.AddressId);
                    sqlConnection.Open();
                    com.ExecuteNonQuery();
                    sqlConnection.Close();
                    return addorder;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Order_Model> GetOrderById(long userid)
        {
            List<Order_Model> orders = new List<Order_Model>();

            sqlConnection = new SqlConnection(ConnString);
            SqlCommand com = new SqlCommand("Sp_GetOrderById", sqlConnection);

            com.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            com.Parameters.AddWithValue("@UserId", userid);
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Order_Model ordermodel = new Order_Model();
                    BookModelForGetOrder booksModel = new BookModelForGetOrder();
                    ordermodel.OrderId = Convert.ToInt32(dr["OrdersId"]);
                    //ordermodel.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                    booksModel.bookName = dr["bookName"].ToString();
                    booksModel.authorName = dr["authorName"].ToString();
                    booksModel.bookId = Convert.ToInt32(dr["bookId"]);
                    booksModel.originalPrice = Convert.ToInt32(dr["originalPrice"]);
                    booksModel.discountPrice = Convert.ToInt32(dr["discountPrice"]);
                    booksModel.bookImage = dr["bookImage"].ToString();
                    ordermodel.bookModel = booksModel;
                    orders.Add(ordermodel);
                }
                dr.Close();
                return orders;
            }
            return null;
        }

        public string DeleteOrder(int OrderId, int UserId)
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteOrder", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OrderId ", OrderId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return "Delete order";
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}

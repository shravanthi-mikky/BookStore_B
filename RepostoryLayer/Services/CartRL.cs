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
    public class CartRL : ICartRL
    {
        private IConfiguration config;
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=BookStore;Integrated Security=True;";
        public CartRL(IConfiguration config)
        {
            this.config = config;
        }

        public CartModel Cartc(CartModel cart)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("Sp_AddCart", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@UserId", cart.UserId);
                    com.Parameters.AddWithValue("@BookId", cart.BookId);
                    com.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    sqlConnection.Open();
                    com.ExecuteNonQuery();
                    sqlConnection.Close();
                    return cart;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteCart(long cartid)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("Sp_DeleteCart", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@CartId", cartid);
                    sqlConnection.Open();
                    int i = com.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public CartModel UpdateCart(long cartid, CartModel cart)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("Sp_UpdateCart", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@CartId", cartid);
                    com.Parameters.AddWithValue("@UserId", cart.UserId);
                    com.Parameters.AddWithValue("@BookId", cart.BookId);
                    com.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    sqlConnection.Open();
                    com.ExecuteNonQuery();
                    sqlConnection.Close();
                    return cart;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<CartModel> RetriveCartDetails(long userid)
        {
            try
            {
                sqlConnection = new SqlConnection(ConnString);
                SqlCommand sqlCommand = new SqlCommand("Sp_RetriveCart", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@UserId", userid);
                SqlDataReader rd = sqlCommand.ExecuteReader();
                if (rd.HasRows)
                {
                    List<CartModel> cartmodel = new List<CartModel>();
                    while (rd.Read())
                    {
                        BookModel booksModel = new BookModel();
                        CartModel cart = new CartModel();


                        //booksModel.bookImage = rd["bookName"].ToString();
                        //booksModel.authorName = rd["authorName"].ToString();
                        //booksModel.bookId = Convert.ToInt32(rd["bookid"]);
                        //booksModel.originalPrice = Convert.ToInt32(rd["originalPrice"]);
                        //booksModel.discountPrice = Convert.ToInt32(rd["discountPrice"]);
                        cart.UserId = Convert.ToInt32(userid);
                        cart.BookId = Convert.ToInt32(rd["BookId"]);
                        cart.Quantity = Convert.ToInt32(rd["Quantity"]);
                       // cart.CartId = Convert.ToInt32(rd["CartId"]);
                        //cart.bookmodel = booksModel;
                        cartmodel.Add(cart);
                    }
                    return cartmodel;
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
        }
    }
}

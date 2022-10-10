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
        public bool DeleteCart(CartModel4 cartModel4)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("Sp_DeleteCart", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@CartId", cartModel4.CartId);
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

        // Get all Cart Details

        public List<CartModel2> GetAllCart()
        {
            try
            {
                sqlConnection = new SqlConnection(ConnString);
                SqlCommand sqlCommand = new SqlCommand("Sp_RetriveAllCart", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader rd = sqlCommand.ExecuteReader();
                if (rd.HasRows)
                {
                    List<CartModel2> cartmodel = new List<CartModel2>();
                    while (rd.Read())
                    {
                        BookModel booksModel = new BookModel();
                        CartModel2 cart = new CartModel2();


                        //booksModel.bookImage = rd["bookName"].ToString();
                        //booksModel.authorName = rd["authorName"].ToString();
                        //booksModel.bookId = Convert.ToInt32(rd["bookid"]);
                        //booksModel.originalPrice = Convert.ToInt32(rd["originalPrice"]);
                        //booksModel.discountPrice = Convert.ToInt32(rd["discountPrice"]);
                        cart.UserId = Convert.ToInt32(rd["UserId"]);
                        cart.BookId = Convert.ToInt32(rd["BookId"]);
                        cart.Quantity = Convert.ToInt32(rd["Quantity"]);
                        cart.CartId = Convert.ToInt32(rd["CartId"]);
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

        // Get All cart details with Join of Book Table

        public List<CartModel3> GetAllCartItems()
        {
            try
            {
                sqlConnection = new SqlConnection(ConnString);
                SqlCommand sqlCommand = new SqlCommand("Sp_RetriveAllCartItems", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader rd = sqlCommand.ExecuteReader();
                if (rd.HasRows)
                {
                    List<CartModel3> cartmodel = new List<CartModel3>();
                    while (rd.Read())
                    {
                        CartModel3 cart = new CartModel3();


                        cart.bookImage = rd["bookImage"].ToString();
                        cart.authorName = rd["authorName"].ToString();
                        cart.BookId = Convert.ToInt32(rd["bookId"]);
                        cart.originalPrice = Convert.ToInt32(rd["originalPrice"]);
                        cart.discountPrice = Convert.ToInt32(rd["discountPrice"]);
                        cart.UserId = Convert.ToInt32(rd["UserId"]);
                       // cart.BookId = Convert.ToInt32(rd["BookId"]);
                       cart.bookName = rd["bookName"].ToString();
                        cart.Quantity = Convert.ToInt32(rd["Quantity"]);
                        cart.CartId = Convert.ToInt32(rd["CartId"]);
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

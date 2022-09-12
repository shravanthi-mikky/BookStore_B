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
    public class WishListRL : IWishListRL
    {
        private readonly IConfiguration configuration;
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=BookStore;Integrated Security=True;";
        public WishListRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        SqlDataReader sqlDataReader;
        List<WishListModel> wishlist = new List<WishListModel>();

        public WishListModel AddWishList(WishListModel wish, int UserId)
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", wish.BookId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return wish;
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

        public string DeleteWishList(int WishListId, int UserId)
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", WishListId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return "Delete WishList";
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

        public IEnumerable<WishListModel> GetWishlist()
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
                try
                {
                    sqlConnection.Open();
                    String query = "SELECT WishListId, BookId FROM Wishlist";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        wishlist.Add(new WishListModel()
                        {
                            WishListId = Convert.ToInt32(sqlDataReader["WishListId"]),
                            BookId = Convert.ToInt32(sqlDataReader["BookId"])

                        });
                    }
                    return wishlist;
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

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
        List<WishListModel1> wishlist1 = new List<WishListModel1>();

        public WishListModel AddWishList(WishListModel wish)
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", wish.BookId);
                    cmd.Parameters.AddWithValue("@UserId ", wish.UserId);

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

        public string DeleteWishList(WishListModel3 wishListModel3)
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", wishListModel3.WishListId);
                    //cmd.Parameters.AddWithValue("@UserId ", UserId);

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


        //trial method

        public string DeleteWishList1()
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", 6);
                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result != 0)
                    { return "Delete WishList"; }
                    else
                    { return null; }
                }
                catch (Exception)
                { throw; }
                finally
                { sqlConnection.Close(); }
            }
        }

        public IEnumerable<WishListModel1> GetWishlist()
        {
            sqlConnection = new SqlConnection(ConnString);
            using (sqlConnection)
                try
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("Sp_GetAllWishListItems", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    //String query = "SELECT * FROM Wishlist";
                    //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        wishlist1.Add(new WishListModel1()
                        {
                            WishListId = Convert.ToInt32(sqlDataReader["WishListId"]),
                            BookId = Convert.ToInt32(sqlDataReader["BookId"]),
                            UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                            bookImage = sqlDataReader["bookImage"].ToString(),
                            authorName = sqlDataReader["authorName"].ToString(),
                            originalPrice = Convert.ToInt32(sqlDataReader["originalPrice"]),
                            discountPrice = Convert.ToInt32(sqlDataReader["discountPrice"]),
                            bookName = sqlDataReader["bookName"].ToString(),

                        });
                    }
                    return wishlist1;
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

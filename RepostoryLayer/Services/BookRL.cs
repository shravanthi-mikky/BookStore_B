using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepostoryLayer.Services
{
    public class BookRL : IBookRL
    {
        private IConfiguration config;
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=BookStore;Integrated Security=True;";
        public BookRL(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateJWTToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Email", email) }),
                Expires = DateTime.UtcNow.AddDays(11),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public BookModel AddBook(BookModel book)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("Sp_AddBook", sqlConnection);
                    com.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlConnection.Open();
                    //com.Parameters.AddWithValue("@bookId", book.bookName);
                    com.Parameters.AddWithValue("@bookName", book.bookName);
                    com.Parameters.AddWithValue("@authorName", book.authorName);
                    com.Parameters.AddWithValue("@rating", book.rating);
                    com.Parameters.AddWithValue("@totalRating", book.totalRating);
                    com.Parameters.AddWithValue("@discountPrice", book.discountPrice);
                    com.Parameters.AddWithValue("@originalPrice", book.originalPrice);
                    com.Parameters.AddWithValue("@description", book.description);
                    com.Parameters.AddWithValue("@bookImage", book.bookImage);
                    com.Parameters.AddWithValue("@BookCount", book.BookCount);
                    //com.Parameters.AddWithValue("@AdminId", book.AdminId);

                    com.ExecuteNonQuery();
                    return book;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public BookModel UpdateBook(BookModel book, long bookid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnString);
                using (conn)
                {

                    SqlCommand com = new SqlCommand("Sp_Updatebook", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@bookId", bookid);
                    com.Parameters.AddWithValue("@bookName", book.bookName);
                    com.Parameters.AddWithValue("@authorName", book.authorName);
                    com.Parameters.AddWithValue("@rating", book.rating);
                    com.Parameters.AddWithValue("@totalRating", book.totalRating);
                    com.Parameters.AddWithValue("@discountPrice", book.discountPrice);
                    com.Parameters.AddWithValue("@originalPrice", book.originalPrice);
                    com.Parameters.AddWithValue("@description", book.description);
                    com.Parameters.AddWithValue("@bookImage", book.bookImage);
                    com.Parameters.AddWithValue("@BookCount", book.BookCount);

                    conn.Open();
                    int i = com.ExecuteNonQuery();
                    conn.Close();
                    if (i >= 1)
                    {
                        return book;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteBook(long bookid)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand com = new SqlCommand("Sp_Delete", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@bookId", bookid);

            conn.Open();
            int i = com.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public object RetriveBookDetails(long bookid)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand com = new SqlCommand("Retrive_1_BookDetails", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@bookId", bookid);
            conn.Open();
            BookModel bookmodel = new BookModel();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    bookmodel.bookId = Convert.ToInt32(rd["bookId"]);
                    bookmodel.bookName = rd["BookName"].ToString();
                    bookmodel.authorName = rd["authorName"].ToString();
                    bookmodel.rating = rd["rating"].ToString();
                    bookmodel.totalRating = Convert.ToInt32(rd["totalRating"]);
                    bookmodel.discountPrice = Convert.ToInt32(rd["discountPrice"]);
                    bookmodel.originalPrice = Convert.ToInt32(rd["originalPrice"]);
                    bookmodel.description = rd["description"].ToString();
                    bookmodel.bookImage = rd["bookImage"].ToString();
                    bookmodel.BookCount = Convert.ToInt32(rd["bookCount"]);
                }
                return bookmodel;
            }
            return null;
        }

        public List<BookModel> GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();
            SqlConnection conn = new SqlConnection(ConnString);
            using (conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpGetAll", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            books.Add(new BookModel
                            {
                                bookId = Convert.ToInt32(reader["bookId"]),
                                bookName = reader["bookName"].ToString(),
                                authorName = reader["authorName"].ToString(),
                                rating = reader["rating"].ToString(),
                                totalRating = Convert.ToInt32(reader["totalRating"]),
                                discountPrice = Convert.ToInt32(reader["discountPrice"]),
                                originalPrice = Convert.ToInt32(reader["originalPrice"]),
                                bookImage = reader["bookImage"].ToString(),
                                description = reader["description"].ToString(),
                                BookCount = Convert.ToInt32(reader["bookCount"])
                            });
                        }

                        return books;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }


    }
}

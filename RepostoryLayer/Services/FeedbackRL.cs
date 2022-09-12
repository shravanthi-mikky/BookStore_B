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
    public class FeedbackRL : IFeedbackRL
    {
        private readonly IConfiguration configuration;
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=BookStore;Integrated Security=True;";
        public FeedbackRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public FeedbackModel AddFeedback(FeedbackModel addfeedback)
        {
            try
            {
                sqlConnection = new SqlConnection(ConnString);
                using (sqlConnection)
                {
                    SqlCommand com = new SqlCommand("Sp_AddFeedback", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@UserId", addfeedback.UserId);
                    com.Parameters.AddWithValue("@BookId", addfeedback.BookId);
                    com.Parameters.AddWithValue("@Comment", addfeedback.Comments);
                    com.Parameters.AddWithValue("@Ratings", addfeedback.Ratings);

                    sqlConnection.Open();
                    com.ExecuteNonQuery();
                    sqlConnection.Close();
                    return addfeedback;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<FeedbackModel> RetrieveFeedBackDetails(int bookId)
        {
            try
            {
                sqlConnection = new SqlConnection(ConnString);
                using (sqlConnection)
                {
                    //string storeprocedure = "spGetFeedbacks";
                    //SqlCommand sqlCommand = new SqlCommand(storeprocedure, sqlConnection);
                    //SqlCommand sqlCommand = new SqlCommand("spGetFeedbacks", sqlConnection);
                    //sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    String query = "SELECT * FROM Feedback";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@BookId", bookId);
                    sqlConnection.Open();
                    SqlDataReader sqlData = sqlCommand.ExecuteReader();
                    List<FeedbackModel> feedback = new List<FeedbackModel>();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            FeedbackModel feedbackModel = new FeedbackModel();
                            //UserModel user = new UserModel();
                            //user.Fullname = sqlData["Fullname"].ToString();
                            feedbackModel.Comments = sqlData["Comment"].ToString();
                            feedbackModel.Ratings = Convert.ToInt32(sqlData["Ratings"]);
                            feedbackModel.UserId = Convert.ToInt32(sqlData["UserId"]);
                            feedbackModel.BookId = Convert.ToInt32(sqlData["BookId"]);
                            //feedbackModel.User = user;
                            feedback.Add(feedbackModel);
                        }
                        return feedback;
                    }
                    return null;

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
    }
}

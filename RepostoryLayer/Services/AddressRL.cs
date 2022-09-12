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
    public class AddressRL : IAddressRL
    {
        private readonly IConfiguration configuration;
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=BookStore;Integrated Security=True;";
        public AddressRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        SqlDataReader sqlDataReader;

        public AddressModel AddAddress(AddressModel addAddress)
        {

            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("SpAddress", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    //com.Parameters.AddWithValue("@AddressId", addAddress.AddressId);
                    com.Parameters.AddWithValue("@Address", addAddress.Address);
                    com.Parameters.AddWithValue("@City", addAddress.City);
                    com.Parameters.AddWithValue("@State", addAddress.State);
                    com.Parameters.AddWithValue("@Type", addAddress.Type);
                    com.Parameters.AddWithValue("@Userid", addAddress.UserId);
                    sqlConnection.Open();
                    com.ExecuteNonQuery();
                    sqlConnection.Close();
                    return addAddress;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Address_Model UpdateAddress(Address_Model addAddress)
        {
            sqlConnection = new SqlConnection(ConnString);
            SqlCommand com = new SqlCommand("Sp_UpdateAddress", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@AddressId", addAddress.AddressId);
            com.Parameters.AddWithValue("@Address", addAddress.Address);
            com.Parameters.AddWithValue("@City", addAddress.City);
            com.Parameters.AddWithValue("@State", addAddress.State);
            com.Parameters.AddWithValue("@Type", addAddress.Type);

            sqlConnection.Open();
            int i = com.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
            {
                return addAddress;
            }
            return null;
        }

        public List<AddressModel> GetUserAddress()
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Sp_GetUserAddress", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader readData = cmd.ExecuteReader();
                    List<AddressModel> userdetaillist = new List<AddressModel>();
                    if (readData.HasRows)
                    {
                        while (readData.Read())
                        {
                            AddressModel userDetail = new AddressModel();
                            //userDetail.AddressId = readData.GetInt32("AddressId");
                            userDetail.Address = readData.GetString("Address");
                            userDetail.City = readData.GetString("City");
                            userDetail.State = readData.GetString("State");
                            userDetail.Type = readData.GetInt32("Type");
                            userdetaillist.Add(userDetail);
                        }
                    }
                    return userdetaillist;
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<AddressModel> GetUserAddressById(long userid)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Sp_GetUserAddressById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    SqlDataReader readData = cmd.ExecuteReader();
                    List<AddressModel> userdetaillist = new List<AddressModel>();
                    if (readData.HasRows)
                    {
                        while (readData.Read())
                        {
                            AddressModel userDetail = new AddressModel();
                            //userDetail.AddressId = readData.GetInt32("AddressId");
                            userDetail.UserId = readData.GetInt32("UserId");
                            userDetail.Address = readData.GetString("Address");
                            userDetail.City = readData.GetString("City");
                            userDetail.State = readData.GetString("State");
                            userDetail.Type = readData.GetInt32("Type");
                            userdetaillist.Add(userDetail);
                        }
                    }
                    return userdetaillist;
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}

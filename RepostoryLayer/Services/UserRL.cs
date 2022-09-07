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
    public class UserRL : IUserRL
    {
        private IConfiguration config;
        SqlConnection sqlConnection;
        public UserRL(IConfiguration config)
        {
            this.config = config;
        }
        public bool Register(RegistrationModel registrationModel)
        {
            sqlConnection = new SqlConnection(this.config.GetConnectionString("BookStoreDB"));
            using(sqlConnection)
                try
                {
                    //var password = this.EncryptPassword(registrationModel.Password);
                    var password = registrationModel.Password;
                    SqlCommand sqlCommand = new SqlCommand("dbo.SP_Register", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Fullname", registrationModel.Fullname);
                    sqlCommand.Parameters.AddWithValue("@Email", registrationModel.Email);
                    sqlCommand.Parameters.AddWithValue("@Mobile", registrationModel.Mobile);
                    sqlCommand.Parameters.AddWithValue("@Password", registrationModel.Password);

                    int result = sqlCommand.ExecuteNonQuery();
                    if(result > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
        //JWT Method
        public string GenerateJWTToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Email", email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string Login(LoginModel loginModel)
        {
            sqlConnection = new SqlConnection(this.config.GetConnectionString("BookStoreDB"));
            SqlCommand sqlCommand = new SqlCommand("dbo.SP_Login", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@Email", loginModel.Email);
            sqlCommand.Parameters.AddWithValue("@Password", loginModel.Password);
            sqlConnection.Open();
            SqlDataReader rd = sqlCommand.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    loginModel.Email = Convert.ToString(rd["Email"] == DBNull.Value ? default : rd["Email"]);
                    loginModel.Password = Convert.ToString(rd["Password"] == DBNull.Value ? default : rd["Password"]);
                }
                var token = this.GenerateJWTToken(loginModel.Email);
                return token;
            }
            return null;

        }
    }
}

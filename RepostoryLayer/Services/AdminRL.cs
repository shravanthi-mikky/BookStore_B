using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepostoryLayer.Services
{
    public class AdminRL : IAminRL
    {
        private IConfiguration config;
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=BookStore;Integrated Security=True;";
        public AdminRL(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateJWTToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Role, "AdminTable"),
                     new Claim("Email", email) }),
                Expires = DateTime.UtcNow.AddDays(11),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string AdminLogin(AdminLoginModel adminModel)
        {
            using (sqlConnection = new SqlConnection(ConnString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.SP_AdminLogin", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@AdminEmail", adminModel.AdminEmail);
                    sqlCommand.Parameters.AddWithValue("@AdminPassword", adminModel.AdminPassword);

                    SqlDataReader rd = sqlCommand.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            adminModel.AdminEmail = Convert.ToString(rd["AdminEmail"] == DBNull.Value ? default : rd["AdminEmail"]);
                            adminModel.AdminPassword = Convert.ToString(rd["AdminPassword"] == DBNull.Value ? default : rd["AdminPassword"]);
                        }
                        var token = this.GenerateJWTToken(adminModel.AdminEmail);
                        return token;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                finally { sqlConnection.Close(); }

        }
    }
}

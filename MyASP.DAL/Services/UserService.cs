using Microsoft.Extensions.Configuration;
using MyASP.DAL.Interfaces;
using MyASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Services
{
    public class UserService : BaseRepository<User>, IUserService
    {
        public UserService(IConfiguration config) : base(config) { }

        protected override User Mapper(IDataReader reader)
        {
            return new User
            {
                Id = (int)reader["u_id"],
                Username = (string)reader["u_name"],
                Email = (string)reader["u_email"],
                RoleId = (int)reader["u_role_id"],
                RoleName = ((int)reader["u_role_id"] == 1 ? "User" : (int)reader["u_role_id"] == 2 ? "Modo" : "Admin"),
            };
        }

        public User Login(string email, string pwd)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UserLogin";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("pwd", pwd);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("test");
                    try
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine(Mapper(reader).Username);
                            return Mapper(reader);
                        }
                        throw new Exception("Connexion Error : Email or Password invalid");
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        _connection.Close();
                    }
                }
            }
        }

        public bool Register(string email, string pwd, string username)
        {
            try
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "UserRegister";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("pwd", pwd);

                    _connection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool AddGameToList(int gameId, User? currentUser)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO [dbo].[UG_USER_GAME] ([ug_user_id], [ug_game_id])" +
                            " VALUES (@user, @game)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("user", currentUser.Id);
                cmd.Parameters.AddWithValue("game", gameId);

                _connection.Open();
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public bool RemoveGameFromList(int id)
        {
            throw new NotImplementedException();
        }
    }
}

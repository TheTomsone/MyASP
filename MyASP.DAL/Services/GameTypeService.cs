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
    public class GameTypeService : BaseRepository<GameType>, IGameTypeService
    {
        public GameTypeService(IConfiguration config) : base(config) { }

        protected override GameType Mapper(IDataReader reader)
        {
            return new GameType
            {
                Id = (int)reader["t_id"],
                Name = (string)reader["t_name"],
            };
        }

        public void Create(GameType gameType)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO [dbo].[T_TYPE] (t_id, t_name) " +
                            "VALUES (@id, @name)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("id", gameType.Id);
                cmd.Parameters.AddWithValue("name", gameType.Name);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();

            }
        }

    }
}

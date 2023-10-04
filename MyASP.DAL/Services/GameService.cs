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
    public class GameService : BaseRepository<Game>, IGameService
    {
        public GameService(IConfiguration config) : base(config) {}

        protected override Game Mapper(IDataReader reader)
        {
            return new Game
            {
                Id = (int)reader["g_id"],
                Title = (string)reader["g_title"],
                Resume = (string)reader["g_resume"],
                GameType = (string)reader["GameTypes"],
            };
        }

        public void Create(Game game)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO [dbo].[G_GAME] (g_title, g_resume, g_type) " +
                            "VALUES (@title, @resume, @type)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("title", game.Title);
                cmd.Parameters.AddWithValue("resume", game.Resume);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();

            }
        }

        public IEnumerable<Game> FilterByType(int typeId)
        {
            List<Game> list = new List<Game>();

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SP_FILTERGAMEBYTYPE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("typeId", typeId);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Mapper(reader));
                    }
                }
                _connection.Close();
            }

            return list;
        }
    }
}

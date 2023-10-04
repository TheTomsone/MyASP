using Microsoft.Extensions.Configuration;
using MyASP.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Services
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected readonly string _connectionString;
        protected readonly SqlConnection _connection;
        public BaseRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
            _connection = new SqlConnection(_connectionString);
        }
        protected abstract TModel Mapper(IDataReader reader);

        public virtual IEnumerable<TModel> GetAll(string tablename)
        {
            List<TModel> list = new();

            _connection.Open();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM " + tablename;
                cmd.CommandText = sql;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Mapper(reader));
                    }
                }
            }
            _connection.Close();

            return list;
        }

        public virtual TModel Get(string tablename, int id)
        {
            _connection.Open();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string[] parts = tablename.Split('_');
                string sql = $"SELECT * FROM {tablename} WHERE [{parts[0].ToString().ToLower()}_id] = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandText = sql;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        return Mapper(reader);
                    }
                    finally
                    {
                        _connection.Close();
                    }
                }
            }
        }

        public virtual void Delete(string tablename, int id)
        {
            _connection.Open();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = $"DELETE FROM {tablename} WHERE [{tablename[0].ToString().ToLower()}_id] = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}

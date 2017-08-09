using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using RealmdigitalInterview.Core.Interfaces;
using System.Data;

namespace RealmdigitalInterview.Core.Implementations
{
    public class SqlRepo : IRepoService
    {
        private IConnection _connection;

        public SqlRepo(IConnection connection)
        {
            _connection = connection;
        }

        public T Add<T>(string command, object parameters)
        {
            return Query<T>(command, parameters).FirstOrDefault();
        }

        public T Delete<T>(string command, object parameters)
        {
            return Query<T>(command, parameters).FirstOrDefault();
        }

        public T Edit<T>(string command, object parameters)
        {
            return Query<T>(command, parameters).FirstOrDefault();
        }

        public T GetModel<T>(string command, object parameters)
        {
            return Query<T>(command, parameters).FirstOrDefault();
        }

        public List<T> GetCollection<T>(string command)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                var result = Query<T>(command, null).ToList();

                return result;
            }
        }

        public List<T> GetCollection<T>(string command, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                var result = conn.Query<T>(command, null, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        private IEnumerable<T> Query<T>(string command, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                var result = conn.Query<T>(command, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}

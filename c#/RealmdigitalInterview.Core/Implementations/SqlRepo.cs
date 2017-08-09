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
            return QueryFirst<T>(command, parameters);
        }

        public T Delete<T>(string command, object parameters)
        {
            return QueryFirst<T>(command, parameters);
        }

        public T Edit<T>(string command, object parameters)
        {
            return QueryFirst<T>(command, parameters);
        }

        public List<T> GetCollection<T>(string command)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                var result = conn.Query<T>(command, null, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public T GetModel<T>(string command, object parameters)
        {
            return QueryFirst<T>(command, parameters);
        }
                
        public T GetModelByFilter<T>(string command, object parameters)
        {
            return QueryFirst<T>(command, parameters);
        }

        private T QueryFirst<T>(string command, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                var result = conn.Query<T>(command, parameters, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }
    }
}

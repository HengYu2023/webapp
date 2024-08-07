using System.Data;
using DataAccess.Interface;
using Microsoft.Data.SqlClient;

namespace DataAccess.Helper;

public class DapperDbHelper : IDbHelper
{
    private readonly string _connectionString;

    public DapperDbHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
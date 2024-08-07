using System.Data;

namespace DataAccess.Interface;

public interface IDbHelper
{
    IDbConnection GetConnection();
}
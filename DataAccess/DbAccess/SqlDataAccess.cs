using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    //We use Dapper to connect to our SQL Server
    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        //We connect to the database
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        //We return the data from the database
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);


    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        //Connect to Database
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        //We execute the stored procedure
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}

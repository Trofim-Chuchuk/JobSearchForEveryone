using Dapper;
using Npgsql;

namespace Resunet.DAL; 

public static class DbHelper {

    public static string ConnString = "User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=Tanos";
    public static async Task ExecuteAsync(string sql, object model)
    {
        using (var connection = new NpgsqlConnection(DbHelper.ConnString))
        {
            await connection.OpenAsync();
            await connection.ExecuteAsync(sql, model);
        }
    }
    public static async Task<T> QueryScalarAsync<T>(string sql, object model)
    {
        using (var connection = new NpgsqlConnection(DbHelper.ConnString))
        {
            await connection.OpenAsync();

            return await connection.QueryFirstOrDefaultAsync<T>(sql, model);
        }
    }
    public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, object model)
    {
        using (var connection = new NpgsqlConnection(DbHelper.ConnString))
        {
            await connection.OpenAsync();

            return await connection.QueryAsync<T>(sql, model);
        }
    }
}
using Dapper;
using Npgsql;
using Resunet.DAL.Model;

namespace Resunet.DAL; 

public class DbSessionDAL:IDbSessionDAL {

    public async Task<int> CreateSession(SessionModel model)
    {
        using (var connection = new NpgsqlConnection(DbHelper.ConnString))
        {
            await connection.OpenAsync();
            string sql = @"insert into DbSession (DbSessionID, SessionData, Created, LastAccessed, UserId)
                      values (@DbSessionID, @SessionContent, @Created, @LastAccessed, @UserId)";

            return await connection.ExecuteAsync(sql, model);
        }
    }

    public async Task<SessionModel?> GetSession(Guid sessionId)
    {
        using (var connection = new NpgsqlConnection(DbHelper.ConnString))
        {
            await connection.OpenAsync();
            string sql = @"SELECT DbSessionID, SessionData, Created, LastAccessed, UserId FROM DbSession WHERE DbSessionID = @sessionId";

            var sessions = await connection.QueryAsync<SessionModel>(sql, new { sessionId = sessionId });
            return sessions.FirstOrDefault();
        }
    }

    public async Task<int> UpdateSession(SessionModel model)
    {
        using (var connection = new NpgsqlConnection(DbHelper.ConnString))
        {
            await connection.OpenAsync();
            string sql = @"update DbSession
                      set SessionData = @SessionData, LastAccessed = @LastAccessed, UserId = @UserId
                      where DbSessionID = @DbSessionID
                ";

            return await connection.ExecuteAsync(sql, model);
        }
    }
    
}
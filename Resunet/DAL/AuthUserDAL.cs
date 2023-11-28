using Dapper;
using Npgsql;

using Resunet.DAL.Model;

namespace Resunet.DAL; 

public class AuthUserDAL:IAuthUserDAL {
    

    public async Task<UserModel> GetUser(int Id){
        using (var connect=new NpgsqlConnection(DbHelper.ConnString)) {
            await connect.OpenAsync();
          return await connect.QueryFirstOrDefaultAsync<UserModel>
              (@"SELECT UserId,Email,Password FROM AppUser WHERE UserId=@Id",
                  new {Id=Id})??new UserModel();
        }
    }

    public async Task<UserModel> GetUser(string email){
        using (var connect=new NpgsqlConnection(DbHelper.ConnString)) {
            await connect.OpenAsync();
            return await connect.QueryFirstOrDefaultAsync<UserModel>
                (@"SELECT UserId,Email,Password,Salt FROM AppUser WHERE email=@email",
                    new {email=email})??new UserModel();
        }
    }

    public async Task<int> CreateUser(UserModel model)
    {
        using (var connection = new NpgsqlConnection(DbHelper.ConnString))
        {
            await connection.OpenAsync();
            string sql = @"insert into AppUser(Email, Password, Salt, Status)
                        values(@Email, @Password, @Salt, @Status) returning UserId";
            return await connection.QuerySingleAsync<int>(sql, model);
        }
    }
}
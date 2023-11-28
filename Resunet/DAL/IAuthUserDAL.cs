using Resunet.DAL.Model;

namespace Resunet.DAL; 

public interface IAuthUserDAL {
    Task<UserModel> GetUser(string email);
    Task<UserModel> GetUser(int id);
    Task<int> CreateUser(UserModel model);
}
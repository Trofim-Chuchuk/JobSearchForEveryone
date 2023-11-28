

using System.ComponentModel.DataAnnotations;

namespace Resunet.BL; 

public interface IAuthBL {
     Task<int> CreateUser(Resunet.DAL.Model.UserModel userModel);
     Task<int> Authenticate(string email, string password, bool rememberMe);
     Task<ValidationResult> ValidateEmail(string email);
}
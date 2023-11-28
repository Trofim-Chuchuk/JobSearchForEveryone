using Resunet.DAL;
using Resunet.DAL.Model;
using Resunet.ViewModels;

namespace Resunet.ViewMapper; 

public class AuthMapper {
    public static UserModel MapRegisterViewModelToUserModel(RegisterViewModel registerViewModel){
        return new UserModel() {
            Email = registerViewModel.Email!,
            Password = registerViewModel.Password! 
        };
    }
}
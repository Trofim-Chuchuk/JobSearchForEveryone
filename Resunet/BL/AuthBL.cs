using System.ComponentModel.DataAnnotations;
using Resunet.BL.Exception;
using Resunet.DAL;
using Resunet.DAL.Model;

namespace Resunet.BL; 

public class AuthBL:IAuthBL {
    private readonly IAuthUserDAL authUserDAL;
    private readonly IEncrypt encrypt;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IDbSession dbSession;

    public AuthBL(
        IAuthUserDAL authUserDal,
        IEncrypt encrypt,
        IHttpContextAccessor httpContextAccessor,
        IDbSession dbSession){
        this.authUserDAL = authUserDal;
        this.encrypt = encrypt;
        this.httpContextAccessor = httpContextAccessor;
        this.dbSession = dbSession;
    }

    public async Task<int> CreateUser(UserModel userModel){
        userModel.Salt = Guid.NewGuid().ToString();
        userModel.Password= encrypt.HashPassword(userModel.Password, userModel.Salt);
        
        int id= await authUserDAL.CreateUser(userModel);
        await Login(id);
        return id;
    }

    public async Task<int> Authenticate(string email, string password, bool rememberMe){
        var user = await authUserDAL.GetUser(email);

        if (user.UserId != null && user.Password == encrypt.HashPassword(password, user.Salt))
        {
            await Login(user.UserId ?? 0);
            return user.UserId ?? 0;
        }
        throw new AuthorizationException();
    }
    public async Task Login(int id){
        await dbSession.SetUserId(id);
    }
    public async Task<ValidationResult> ValidateEmail (string email){
        var user = await authUserDAL.GetUser(email);
        if (user.UserId!=null) 
            return new ValidationResult("email уже существует");
        return null;
    }
}
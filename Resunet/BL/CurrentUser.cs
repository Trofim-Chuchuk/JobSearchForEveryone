namespace Resunet.BL; 

public class CurrentUser:ICurrentUser {
    private readonly IDbSession dbSession;
    private readonly IHttpContextAccessor httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor,IDbSession dbSession){
        this.httpContextAccessor = httpContextAccessor;
        this.dbSession = dbSession;
    }

    public async Task<bool> IsLoggedIn(){
        return await dbSession.IsLoggedIn();
    }
}
namespace Resunet.BL; 

public interface ICurrentUser {
    Task<bool> IsLoggedIn();
}
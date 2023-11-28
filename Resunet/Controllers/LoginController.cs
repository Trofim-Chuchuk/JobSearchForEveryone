using Microsoft.AspNetCore.Mvc;
using Resunet.BL;
using Resunet.ViewMapper;
using Resunet.ViewModels;

namespace Resunet.Controllers; 

public class LoginController:Controller {
    private readonly IAuthBL authBL;

    public LoginController(IAuthBL authBL){
        this.authBL = authBL;
    }

    
    
    [HttpGet]
    [Route("/login")]
    public IActionResult Index(){
        return View("Index", new LoginViewModel());
    }
    
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> IndexSave(LoginViewModel model) {
        if (ModelState.IsValid) {
            try {
                await authBL.Authenticate(model.Email!,model.Password!,model.RememberMe==true);
                return Redirect("/");
            }
            catch (BL.Exception.AuthorizationException) {
                ModelState.AddModelError("Email","Имя или Email неверные");
            }
        }
        return View("Index", model);
    }
}
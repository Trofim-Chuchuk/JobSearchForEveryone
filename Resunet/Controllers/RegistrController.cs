using Microsoft.AspNetCore.Mvc;
using Resunet.BL;
using Resunet.ViewMapper;
using Resunet.ViewModels;

namespace Resunet.Controllers; 

public class RegistrController:Controller {
    private readonly IAuthBL authBL;

    public RegistrController(IAuthBL authBL){
        this.authBL = authBL;
    }

    [HttpGet]
    [Route("/registr")]
    public IActionResult Index(){
        return View("Index", new RegisterViewModel());
    }
    
    [HttpPost]
    [Route("/registr")]
    public async Task<IActionResult> IndexSave(RegisterViewModel model){
        if (ModelState.IsValid) {
            bool isValid = true;
            var errorModel = await authBL.ValidateEmail(model.Email ?? "");
            if (errorModel != null)
                ModelState.TryAddModelError("Email", errorModel.ErrorMessage!);
        }
        if (ModelState.IsValid) {
        var a= await authBL.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));
         return Redirect("/");
        }
        return View("Index", model);
    }
    
}
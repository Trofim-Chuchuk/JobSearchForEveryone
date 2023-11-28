using Microsoft.AspNetCore.Mvc;
using Resunet.BL;
using Resunet.DAL;
using Resunet.DAL.Model;

namespace Resunet.Controllers; 

public class HomeController:Controller {

    private readonly ICurrentUser currentUser;

    public HomeController(ICurrentUser currentUser){
        this.currentUser = currentUser;
    }
    
    
   
    public async Task<IActionResult> Index(){
     var  isLoggedIn=await currentUser.IsLoggedIn();
     return View(isLoggedIn);
    }
}
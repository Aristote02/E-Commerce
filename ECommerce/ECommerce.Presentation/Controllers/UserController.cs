using ECommerce.BusinessLogic.Requests;
using ECommerce.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.Presentation.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRequest userRequest)
    {
        if(ModelState.IsValid)
        {
            await _userService.AddAsync(userRequest);
            return RedirectToAction("Index", "Home");
        }
        
        return View();
    }
}

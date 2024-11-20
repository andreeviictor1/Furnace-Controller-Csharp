// Controllers/UserController.cs
using Bake_Controller.Data;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    //private readonly ApplicationDbContext _context;

    //public UserController(ApplicationDbContext context)
    //{
    //    _context = context;
    //}

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        //var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        //if (user != null)
        //{
        //    HttpContext.Session.SetString("Username", user.Username);
        //    return RedirectToAction("Control", "Furnace");
        //}

        ViewBag.ErrorMessage = "Invalid login credentials";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Username");
        return RedirectToAction("Login");
    }
}

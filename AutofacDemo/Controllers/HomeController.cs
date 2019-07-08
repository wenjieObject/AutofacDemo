using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AutofacDemo.Models;
using IService;
using Service;

namespace AutofacDemo.Controllers
{
    public class HomeController : Controller
    {
        private IUser _user;

        public HomeController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            var s= _user.getUser(1);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

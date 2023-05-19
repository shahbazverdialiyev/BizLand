using BizLand.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BizLand.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agripoint.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}

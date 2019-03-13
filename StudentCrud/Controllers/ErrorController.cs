using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult StatusPage(int code)
        {
            if (code == 777)
            {
                ViewData["message"] = "Ne játsz a modify-al hülyegyerek!";
            }
            return View();
        }
    }
}

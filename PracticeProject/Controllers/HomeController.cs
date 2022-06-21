using Microsoft.AspNetCore.Mvc;
using PracticeProject.Models;
using System.Diagnostics;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Contact()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Contact(string Name, string Email)
        //{
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(IFormCollection col)
        {
            List<String> Total = new List<string>();
            foreach (string Key in col.Keys)
            {
                if (!Key.Contains("__RequestVerificationToken"))
                {
                    string value = col[Key];
                    Total.Add(value);
                }

            }
            return View(Total);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Contact(ContactViewModel viewModel)
        //{
        //   ViewBag.ContactName = viewModel.Name;
        //   ViewBag.ContactEmail = viewModel.Email;


        //    return View();
        //}

        public IActionResult Index()
        {
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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JCSoft.Core.HttpClient;
using Microsoft.AspNetCore.Mvc;
using JCSoft.Core.HttpClientDemo.Models;

namespace JCSoft.Core.HttpClientDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpHelper _httpHelper;

        public HomeController(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

        [HttpPost]
        public async Task<IActionResult> SendData(string url, string data, string method)
        {
            var model = String.Empty;

            switch (method)
            {
                case "Get":
                    model = await _httpHelper.GetAsync(url);
                    break;
                case "Post":
                    model = await _httpHelper.PostAsync(url, data);
                    break;
                case "Put":
                    model = await _httpHelper.PutAsync(url, data);
                    break;
                case "Delete":
                    model = await _httpHelper.DeleteAsync(url);
                    break;
            }

            return View("Index", model);
        }
    }
}

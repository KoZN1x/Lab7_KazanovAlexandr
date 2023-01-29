using Lab7_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Lab7_KazanovAlexandr.Controllers
{
    public class TaskController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TaskController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult FirstTask()
        {
            var model = new FirstTaskModel();
            model.name = "Alexandr Kazanov";
            model.date = DateTime.Now.ToString();
            model.applicationName = _webHostEnvironment.ApplicationName;
            model.environment = _webHostEnvironment.EnvironmentName;
            model.host = HttpContext.Request.Host.Value;
            model.protocol = HttpContext.Request.Protocol;
            return View(model);
        }

        public IActionResult SecondTask()
        {
            var obj = new ObjectController();
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true               
            };
            ViewBag.json = JsonSerializer.Serialize(obj, jsonOptions);
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult ThirdTask(string name, int age, double money)
        {
            ViewData["name"] = name;
            ViewData["age"] = age;
            ViewData["money"] = money;
            return View();
        }
    }
}

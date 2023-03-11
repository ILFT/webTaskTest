using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Models.Db;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<TaskViewModel> tasks = (new DbTasks().AllTasks());
            return View(tasks);
        }

        public IActionResult AddTask()
        {
            ViewData["Tags"] = new DbTags().AllTags();
            ViewData["Categories"] = new DbCategories().AllCategories();
            ViewData["Priority"] = new DbPriorites().AllPriorites();
            return View(); 
        }

        public IActionResult CreateTask()
        {
            return RedirectToAction("Index");
        }

        public IActionResult FinishTask(int id)
        {
            new DbTasks().FinishTask(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
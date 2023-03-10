using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public IActionResult CreateTask(string name, DateTime deadline, string[] tags, string category, string priority, string comment)
        {
            new DbTasks().AddTask(new TaskViewModel(name, DateOnly.FromDateTime(deadline), category, priority, comment, tags));
            return RedirectToAction("Index");
        }

        public IActionResult RedactTask(int id)
        {

            TaskViewModel task = new DbTasks().GetTasks(id);
            
            ViewData["Tags"] = new DbTags().AllTags();
            ViewData["Categories"] = new DbCategories().AllCategories();
            ViewData["Priority"] = new DbPriorites().AllPriorites();

            return View(task);
        }
        public IActionResult UpdateTask(int id, string name, DateTime DateCreate, DateTime DateFinish, DateTime deadline, string[] tags, string category, string priority, string comment)
        {
            Console.WriteLine(id);


            new DbTasks().UpdateTask(new TaskViewModel(id, name, DateOnly.FromDateTime(DateCreate), DateOnly.FromDateTime(DateFinish), DateOnly.FromDateTime(deadline), category, priority, comment, tags));
            
            return RedirectToAction("Index");
        }

        public IActionResult FinishTask(int id)
        {
            new DbTasks().FinishTask(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(int id)
        {
            new DbTasks().DeleteTask(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
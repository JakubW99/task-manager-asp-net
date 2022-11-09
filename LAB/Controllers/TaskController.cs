using Microsoft.AspNetCore.Mvc;
using LAB.Models;
namespace LAB.Controllers
{
    public class TaskController : Controller
    {
        private static List<Models.Task> tasks = new List<Models.Task>()
        {
            new Models.Task()
            {
                Id =1, Email = "jan@wp.pl", Author= "Janek", TaskName = "Zakupy", Description =" Zrób zakupy"
            },
            new Models.Task()
            {
                Id =2, Email = "nowak@gmail.com", Author= "Adam", TaskName = "Jedź do banku", Description ="Zrób przelew"
            },
            new Models.Task()
            {
                Id =3, Email = "pawel@outlook.com", Author= "Pablo", TaskName = "Uczelnia", Description ="Ucz się"
            }
        };
        int counter = tasks.Count;
        public IActionResult Index()
        {

            return View(tasks);
        }
        public IActionResult Delete(int id)
        {

            tasks.RemoveAt(id);
            counter--;
            return View("Index", tasks);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }

      
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Form(LAB.Models.Task task)
        {

            if (ModelState.IsValid)
            {
                tasks.Add(task);
                return View("Index",tasks);
            }
            else
            {
                return View();
                //ponowne wy

            }

        }
    }
}
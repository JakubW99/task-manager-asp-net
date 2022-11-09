using Microsoft.AspNetCore.Mvc;
using LAB.Models;
using TaskManagaer.Models;
using System.Net;
using System.Data;
using System.Linq;

namespace LAB.Controllers
{
    public class TaskController : Controller
    {
        private static List<Models.Task> tasks = new List<Models.Task>();
        
        private static AppDbContext context = new AppDbContext();
        int counter = tasks.Count;
        public IActionResult Index()
        {
            using (var context = new AppDbContext())
            {

                // Return the list of data from the database
                tasks  = context.Tasks.ToList();
             
                return View(tasks);
            }
          
        }
        public ActionResult Delete()
        {
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var data = context.Tasks.FirstOrDefault(x => x.Id == id);
                if (data != null)
                {
                    context.Tasks.Remove(data);
                    tasks.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View("Index");
            }
        }
        public ActionResult Edit(int Id)
        {
            using (var context = new AppDbContext())
            {
                var data = context.Tasks.Where(x => x.Id == Id).SingleOrDefault();
                return View(data);
            }
        }

        // To specify that this will be
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Models.Task model)
        {
            using (var context = new AppDbContext())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Tasks.FirstOrDefault(x => x.Id == Id);

                // Checking if any such record exist
                if (data != null)
                {
                    data.Author= data.Author;
                    data.Email =data.Email;
                    data.TaskName = model.TaskName;
                    data.Description = model.Description;

                    context.SaveChanges();
                   
                    // It will redirect to
                    // the Read method
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
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
                context.Tasks.Add(task);
                context.SaveChanges();
                tasks.Add(task);
                return View("Index",tasks);
               
            }
            else
            return View();
        }
    }
}
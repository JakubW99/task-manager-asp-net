using Microsoft.AspNetCore.Mvc;
using TaskManagaer.Models;
using System.Data;

namespace LAB.Controllers
{
    public class TaskController : Controller
    {


        private static AppDbContext context = new AppDbContext();

        public IActionResult Index()
        { 
            // Return the list of data from the database
            var data = context.Tasks.ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = context.Tasks.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                context.Tasks.Remove(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View("Index");

        }
        [HttpGet]

        public ActionResult Edit(int Id)
        {

            var data = context.Tasks.Where(x => x.Id == Id).FirstOrDefault();
            return View(data);

        }

        // To specify that this will be
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Models.Task model)
        {


            // Use of lambda expression to access
            // particular record from a database
            var data = context.Tasks.Where(x => x.Id == Id).FirstOrDefault();

            // Checking if any such record exist
            if (data != null)
            {
                data.Author = data.Author;
                data.Email = data.Email;

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


        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(LAB.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Add(task);
                context.SaveChanges();
                // return View("Index", context.Tasks.ToList());
                return RedirectToAction("Index");

            }
            else
                return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using BoxProblem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoxProblem.Controllers
{
    public class BoxController : Controller
    {
        private BoxService service;
        public ActionResult Index(int search1, bool? search2, string search3)
        {

            List<BoxInventory> finalList = service.GetAllBoxes();
            if (search1 != 0)
            {
                finalList = service.Search(search1);
            }
            if (search2 != null)
            {
                finalList = service.Search(search2);
            }
            if (search2 != null)
            {
                finalList = service.Search(search3);
            }
            return View(finalList);

        }

        public BoxController(ApplicationDbContext context){
            service = new BoxService(context);
        }

        public ActionResult Index()
        {
            return View(service.GetAllBoxes());

        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Delete(int id){
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoxInventory box)
        {
            if (ModelState.IsValid && box.Cost > 0 && box.Volume > 0 && box.Weight > 0)
            {
                service.AddBox(box);
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Invalid Input";
            return View("Create",box);
        }
    }
}
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
        private Data.ApplicationDbContext dbContext;
        public BoxController(ApplicationDbContext context)
        {
            service = new BoxService(context);
            dbContext = context;
        }
        public ActionResult Index(string searchBy, int search)
        {

            var finalList = service.GetAllBoxes();
            if (searchBy == "Weight" && search >= 0)
            {
                finalList = service.GetAllBoxes().Where(s => s.Weight == search).ToList();
            }
            if (searchBy == "Volume" && search >= 0)
            {
                finalList = service.GetAllBoxes().Where(s => s.Volume == search).ToList();
            }
            if (searchBy == "Cost" && search >= 0)
            {
                finalList = service.GetAllBoxes().Where(s => s.Cost == search).ToList();
            }

            return View(finalList);

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
        public ActionResult Create(BoxInventory box){
            if(ModelState.IsValid)
            {
                service.AddBox(box);
                return RedirectToAction("Index");
            }
            return View(box);
        }
    }
}

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
        public ActionResult Index(int search1, bool? search2, string search3, double search4)
        {

            List<BoxInventory> finalList = service.GetAllBoxes();
            if (search1 != 0)
            {
                finalList = service.SearchWeightVolume(search1);
            }
            if (search2 != null)
            {
                finalList = service.SearchCanHoldLiquid(search2);
            }
            if (search2 != null)
            {
                finalList = service.Search(search3);
            }
            if(search4 != 0.0)
            {
                finalList = service.SearchCost(search4);
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

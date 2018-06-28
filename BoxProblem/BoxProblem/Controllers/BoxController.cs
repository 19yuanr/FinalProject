
﻿using System;
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

        public BoxController(ApplicationDbContext context){
            service = new BoxService(context);
        }
        public ActionResult Index(string searchBy, int search)
        {

            List<BoxInventory> finalList = service.GetAllBoxes();
            if (searchBy == "Weight")
            {
                finalList = service.GetAllBoxes().Where(s => s.Weight == search).ToList();
            }
            if (searchBy == "Volume")
            {
                finalList = service.GetAllBoxes().Where(s => s.Volume == search).ToList();
            }
            if (searchBy == "Cost" )
            {
                finalList = service.GetAllBoxes().Where(s => s.Cost == search).ToList();
            }
            if(searchBy=="Reset")
            {
                finalList = service.GetAllBoxes();
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
        public ActionResult Edit(int id){
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
        [HttpPost]
        public ActionResult Edit(BoxInventory box){
          if (ModelState.IsValid){
                service.SaveEdits(box);
                return RedirectToAction("Index");
            }
            return View(box);
        }
    }
}


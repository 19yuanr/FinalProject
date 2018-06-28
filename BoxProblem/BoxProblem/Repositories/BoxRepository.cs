using BoxProblem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        private Data.ApplicationDbContext dbContext;

        public BoxRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<BoxInventory> SearchWeight(int temp)
        {
            var results = dbContext.Boxes.Where(s => s.Weight == temp);
            return results.ToList();
        }

        public List<BoxInventory> SearchVolume(int temp)
        {
            var results = dbContext.Boxes.Where(s => s.Volume == temp);
            return results.ToList();
        }

        public List<BoxInventory> SearchCanHoldLiquid(bool? temp)
        {
            var results = dbContext.Boxes.Where(s => s.CanHoldLiquid == temp);
            return results.ToList();
        }

        public List<BoxInventory> SearchCost(double temp)
        {
            var results = dbContext.Boxes.Where(s => s.Cost == temp);
            return results.ToList();
        }
        
        public List<BoxInventory> SearchDateTime(DateTime temp)
        {
            var results = dbContext.Boxes.Where(s => s.CreatedAt == temp);
            return results.ToList();
        }
        public List<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.ToList();
        }
        public void AddBox(BoxInventory toAdd){
            dbContext.Boxes.Add(toAdd);
            dbContext.SaveChanges();
        }
        public void DeleteBox (BoxInventory toDelete){
            dbContext.Boxes.Remove(toDelete);
            dbContext.SaveChanges();
        }
        public BoxInventory GetBoxById(int id){
            return dbContext.Boxes.Find(id);
        }
    }
}


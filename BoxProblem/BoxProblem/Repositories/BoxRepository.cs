using System;
using System.Collections.Generic;
using System.Linq;
using BoxProblem.Data;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        private Data.ApplicationDbContext dbContext;

        public BoxRepository(ApplicationDbContext context)
        {
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

        public List<BoxInventory> SearchCanHoldLiquid(bool temp)
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

    }
}


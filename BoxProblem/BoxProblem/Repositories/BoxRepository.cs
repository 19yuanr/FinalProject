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


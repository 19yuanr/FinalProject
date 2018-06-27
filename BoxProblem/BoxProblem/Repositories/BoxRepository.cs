using System;
using BoxProblem.Data;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        private Data.ApplicationDbContext dbContext;

        public BoxRepository(ApplicationDbContext context)
        {
            dbContext = context;
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


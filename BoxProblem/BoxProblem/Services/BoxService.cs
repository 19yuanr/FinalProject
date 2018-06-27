using System;
using System.Collections.Generic;
using BoxProblem.Data;
using BoxProblem.Repositories;

namespace BoxProblem.Services
{
    public class BoxService
    {

        private BoxRepository repository;
        public List<BoxInventory> GetAllBoxes()
        {
            return repository.GetAllBoxes();
        }
        public BoxService(ApplicationDbContext context)
        {
            repository = new BoxRepository(context);
        }

        public void AddBox(BoxInventory toAdd)
        {
            repository.AddBox(toAdd);
        }
        public BoxInventory GetBoxById(int id){
            return repository.GetBoxById(id);
        }
    }
}

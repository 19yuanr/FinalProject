using BoxProblem.Data;
using BoxProblem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxProblem.Services
{
    public class BoxService
    {
        private BoxRepository repository;

        public BoxService(ApplicationDbContext context)
        {
            repository = new BoxRepository(context);
        }

        public List<BoxInventory> Search(int temp)
        {
            List<BoxInventory> result = repository.SearchWeight(temp);
            List<BoxInventory> result1 = repository.SearchVolume(temp);
            var finalResult = result.Union(result1);
            return finalResult.ToList();
        }

        public List<BoxInventory> Search(bool temp)
        {
            return repository.SearchCanHoldLiquid(temp);
        }

        public List<BoxInventory> Search(double temp)
        {
            return repository.SearchCost(temp);
        }

        public List<BoxInventory> Search(string temp)
        {
            DateTime newTemp = DateTime.Parse(temp);
            return repository.SearchDateTime(newTemp);
        }
        public List<BoxInventory> GetAllBoxes()
        {
            return repository.GetAllBoxes();
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

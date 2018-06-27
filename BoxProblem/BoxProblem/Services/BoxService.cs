using System;
using BoxProblem.Data;
using BoxProblem.Repositories;

namespace BoxProblem.Services
{
    public class BoxService
    {

        private BoxRepository repository;
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
        public void SaveEdits(BoxInventory toSave){
            repository.SaveEdits(toSave);
        }
    }
}

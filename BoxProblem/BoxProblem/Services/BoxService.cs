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
    }
}

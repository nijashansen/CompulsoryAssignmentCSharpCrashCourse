using System.Collections.Generic;
using System.Linq;
using Core.Entity;
using PetShop.Infrastructure.SQL;

namespace PetShop.UI.restAPI.Data
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(PetShopContext context)
        {
            context.Database.EnsureCreated();

            if (context.pets.Any())
            {
                return;
            }

            List<Pet> pets = new List<Pet>
            {
                new Pet {Name = "Jens", Color = "Gray"},
                new Pet {Name = "Søren", Color = "WUppp"}

            };
            
            context.pets.AddRange(pets);
            context.SaveChanges();
        }
    }
}
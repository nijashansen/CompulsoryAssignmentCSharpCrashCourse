using System;
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
            List<Pet> pets = new List<Pet>();


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            List<Owner> owners = new List<Owner>();
            Owner owner1;
            owners.Add(owner1 = new Owner()
            {
                name = "Lone",
                OwnedPets = pets
            });
            Owner owner2;
            owners.Add(owner2 = new Owner()
            {
                name = "Peter",
                OwnedPets = pets
            });
            
            pets.Add(new Pet()
            {
                Name = "John",
                Color = "Blue",
                PrevOwner = owner1
            });
            pets.Add(new Pet()
            {
                Name = "Kris",
                Color = "Orange",
                PrevOwner = owner2
            });

            
            
            context.pets.AddRange(pets);
            context.SaveChanges();
        }
    }
}
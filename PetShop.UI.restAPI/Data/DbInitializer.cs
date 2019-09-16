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
            context.Database.EnsureCreated();

            if (context.pets.Any())
            {
                return;
            }
            
            List<Owner> owners = new List<Owner>
            {
                context.owners.Add(new Owner
                {
                    id = 1,
                    name = "Søgge"
                }).Entity
            };

            List<Pet> pets = new List<Pet>
            {
                context.pets.Add(new Pet
                {
                    ID = 2,
                    Name = "Børge",
                    BirthDay = new DateTime(1997, 2, 5),
                    Color = "Gray",
                    Price = 300000,
                    TypeOfPet = "Goat",
                    SoldDate = new DateTime(2006, 1, 1)
                }).Entity
            };
            
            context.owners.AddRange(owners);
            context.pets.AddRange(pets);
            context.SaveChanges();
        }
    }
}
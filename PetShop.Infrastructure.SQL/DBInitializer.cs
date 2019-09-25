using System;
using System.Collections.Generic;
using Core.Entity;

namespace PetShop.Infrastructure.SQL
{
    public class DBInitializer
    {
        public static void Initialize(PetShopContext ctx)
        {
            Pet pet1 = new Pet
            {
                name = "Felix",
                type = PetTypes.Cat,
                birthDate = DateTime.Now,
                soldDate = DateTime.Now.AddYears(1),
                color = "Black",
                price = 275,
                ownersHistory = new List<PetOwner>()
            };
            Pet pet2 = new Pet
            {
                name = "Steggersaurus",
                type = PetTypes.Dinosaurus,
                birthDate = DateTime.Now.AddYears(-35),
                soldDate = DateTime.Now.AddYears(1).AddDays(24),
                color = "SteggerColor",
                price = 550,
                ownersHistory = new List<PetOwner>()
            };
            Pet pet3 = new Pet
            {
                name = "Snoopy",
                type = PetTypes.Dog,
                birthDate = DateTime.Now.AddYears(-35),
                soldDate = DateTime.Now.AddYears(1).AddDays(24),
                color = "White",
                price = 550,
                ownersHistory = new List<PetOwner>()
            };
            Owner owner1 = new Owner
            {
                firstName = "Post",
                lastName = "Malone",
                address = "Melonvej 24",
                petHistory = new List<PetOwner>()
            };
            Owner owner2 = new Owner
            {
                firstName = "Daft",
                lastName = "Punk",
                address = "Elektronik Musikvej 1337",
                petHistory = new List<PetOwner>()
            };
            Owner owner3 = new Owner
            {
                firstName = "Chris",
                lastName = "McDonnel",
                address = "Tomatvej 40",
                petHistory = new List<PetOwner>()
            };



            owner1 = ctx.Owners.Add(owner1).Entity;
            owner2 = ctx.Owners.Add(owner2).Entity;
            owner3 = ctx.Owners.Add(owner3).Entity;

            PetOwner PetOwner1 = new PetOwner
            {
                Owner = owner1
            };

            PetOwner PetOwner2 = new PetOwner
            {
                Owner = owner2
            };

            PetOwner PetOwner3 = new PetOwner
            {
                Owner = owner1
            };
            
            PetOwner PetOwner4 = new PetOwner
            {
                Owner = owner3
            };

            pet1.ownersHistory.Add(PetOwner1);
            pet1.ownersHistory.Add(PetOwner2);
            pet2.ownersHistory.Add(PetOwner3);
            pet3.ownersHistory.Add(PetOwner4);

            pet1 = ctx.Pets.Add(pet1).Entity;
            pet2 = ctx.Pets.Add(pet2).Entity;
            pet3 = ctx.Pets.Add(pet3).Entity;



            ctx.SaveChanges();
        }
    }
}
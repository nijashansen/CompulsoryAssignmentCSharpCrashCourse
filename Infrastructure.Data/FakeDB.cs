using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public static class FakeDB
    {

        private static List<Pet> _pets = new List<Pet>();
        private static List<Owner> _owners = new List<Owner>();
        internal static int petID = 1;
        internal static int ownerID = 9;

        public static List<Pet> getPets()
        {
            return _pets.ToList();
        }

        public static List<Owner> getOwners()
        {
            return _owners.ToList();
        }

        public static void InitData()
        {
            Owner Mette = new Owner()
            {
                id = ownerID++,
                name = "Mette"
            };

            Owner Mogens = new Owner()
            {
                id = ownerID++,
                name = "Mogens"
            };

            Owner Astrid = new Owner()
            {
                id = ownerID++,
                name = "Astrid"
            };

            Owner Rasmus = new Owner()
            {
                id = ownerID++,
                name = "Rasmus"
            };

            Owner Jon = new Owner()
            {
                id = ownerID++,
                name = "Jon Arbuckle"
            };

            Owner Karina = new Owner()
            {
                id = ownerID++,
                name = "Karina"
            };

            Pet Goat2 = new Pet()
            {
                ID = petID++,
                Name = "Børge",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Gray",
                PrevOwner = Mette,
                Price = 300000,
                TypeOfPet = "Goat",
                SoldDate = new DateTime(2006, 1, 1)
            };

            Pet Goat = new Pet()
            {
                ID = petID++,
                Name = "Jens",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Brown",
                PrevOwner = Mogens,
                Price = 1000,
                TypeOfPet = "Goat",
                SoldDate = new DateTime(2006, 1 ,1)
            };

            Pet Dog2 = new Pet()
            {
                ID = petID++,
                Name = "Marie",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Blue",
                PrevOwner = Astrid,
                Price = 102000,
                TypeOfPet = "Dog",
                SoldDate = new DateTime(2006, 1, 1)
            };

            Pet Dog = new Pet()
            {
                ID = petID++,
                Name = "Skippy",
                BirthDay = new DateTime(2000, 9, 12),
                Color = "Golden",
                PrevOwner = Rasmus,
                Price = 2500,
                TypeOfPet = "Dog",
                SoldDate = new DateTime(2001, 10, 3)
            };

            Pet Cat = new Pet()
            {
                ID = petID++,
                Name = "Garfield",
                BirthDay = new DateTime(2009, 5, 23),
                Color = "Orange",
                PrevOwner = Jon,
                Price = 30000,
                TypeOfPet = "Cat",
                SoldDate = new DateTime(2006, 12, 30)
            };

            Pet Cat2 = new Pet()
            {
                ID = petID++,
                Name = "Felix",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Black",
                PrevOwner = Karina,
                Price = 19000,
                TypeOfPet = "Cat",
                SoldDate = new DateTime(2006, 1, 1)
            };


            _owners.Add(Karina);
            _owners.Add(Jon);
            _owners.Add(Rasmus);
            _owners.Add(Astrid);
            _owners.Add(Mogens);
            _owners.Add(Mette);

            _pets.Add(Cat);
            _pets.Add(Dog);
            _pets.Add(Goat);
            _pets.Add(Goat2);
            _pets.Add(Dog2);
            _pets.Add(Cat2);
            
        }


    }
}

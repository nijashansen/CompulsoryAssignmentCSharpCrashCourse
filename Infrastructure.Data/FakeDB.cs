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
        internal static int id = 1;

        public static List<Pet> getPets()
        {
            return _pets.ToList();
        }

        public static void InitData()
        {
            Pet Goat2 = new Pet()
            {
                ID = id++,
                Name = "Børge",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Gray",
                PrevOwner = "Mette",
                Price = 300000,
                TypeOfPet = "Goat",
                SoldDate = new DateTime(2006, 1, 1)
            };

            Pet Goat = new Pet()
            {
                ID = id++,
                Name = "Jens",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Brown",
                PrevOwner = "Mogens",
                Price = 1000,
                TypeOfPet = "Goat",
                SoldDate = new DateTime(2006, 1 ,1)
            };

            Pet Dog2 = new Pet()
            {
                ID = id++,
                Name = "Marie",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Blue",
                PrevOwner = "Astrid",
                Price = 102000,
                TypeOfPet = "Dog",
                SoldDate = new DateTime(2006, 1, 1)
            };

            Pet Dog = new Pet()
            {
                ID = id++,
                Name = "Skippy",
                BirthDay = new DateTime(2000, 9, 12),
                Color = "Golden",
                PrevOwner = "Rasmus",
                Price = 2500,
                TypeOfPet = "Dog",
                SoldDate = new DateTime(2001, 10, 3)
            };

            Pet Cat = new Pet()
            {
                ID = id++,
                Name = "Garfield",
                BirthDay = new DateTime(2009, 5, 23),
                Color = "Orange",
                PrevOwner = "Jon Arbuckle",
                Price = 30000,
                TypeOfPet = "Cat",
                SoldDate = new DateTime(2006, 12, 30)
            };

            Pet Cat2 = new Pet()
            {
                ID = id++,
                Name = "Felix",
                BirthDay = new DateTime(1997, 2, 5),
                Color = "Black",
                PrevOwner = "Karina",
                Price = 19000,
                TypeOfPet = "Cat",
                SoldDate = new DateTime(2006, 1, 1)
            };

            _pets.Add(Cat);
            _pets.Add(Dog);
            _pets.Add(Goat);
            _pets.Add(Goat2);
            _pets.Add(Dog2);
            _pets.Add(Cat2);
            
        }


    }
}

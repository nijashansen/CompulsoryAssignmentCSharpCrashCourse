using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public static class FakeDB
    {

        private static IEnumerable<Pet> _pets = new List<Pet>();
        private static int id = 1;

        public static List<Pet> getPets()
        {
            return _pets.ToList();
        }

        public static void InitData()
        {
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

            Pet Dog = new Pet()
            {
                ID = id++,
                Name = "Skippy",
                BirthDay = new DateTime(2000, 9, 12),
                Color = "Golden",
                PrevOwner = "Rasmus",
                Price = 2500,
                TypeOfPet = "Doggo",
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
                TypeOfPet = "Fat Cat",
                SoldDate = new DateTime(2006, 12, 30)
            };

            _pets.ToList().Add(Cat);
        }


    }
}

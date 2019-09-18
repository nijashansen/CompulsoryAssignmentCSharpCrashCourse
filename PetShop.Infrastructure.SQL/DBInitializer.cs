using System;
using Core.Entity;

namespace PetShop.Infrastructure.SQL
{
    public class DBInitializer
    {
        public static void Initialize(PetShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var pet1 = ctx.pets.Add(new Pet()
            {
                BirthDay = DateTime.Today,
                Color = "Grå",
                Name = "BlopFisk",
                Price = 2000.00,
                SoldDate = DateTime.Now.AddYears(1),
                TypeOfPet = "Fisk"
            }).Entity;
            
            var pet2 = ctx.pets.Add(new Pet()
            {
                BirthDay = DateTime.Today,
                Color = "Blå",
                Name = "PuffeFisk",
                Price = 2000.00,
                SoldDate = DateTime.Now.AddYears(1),
                TypeOfPet = "Fisk"
            }).Entity;
            
            ctx.owners.Add(new Owner()
            {
                name = "Olga",
                Pet = pet1
            });
            
            ctx.owners.Add(new Owner()
            {
                name = "Poul",
                Pet = pet2
            });
        }
    }
}
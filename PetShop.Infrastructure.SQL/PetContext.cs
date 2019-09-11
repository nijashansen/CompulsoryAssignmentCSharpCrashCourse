using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQL
{
    public class PetContext: DbContext
    {
        public DbSet<Pet> pets { get; set; }
    }
}

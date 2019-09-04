using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string TypeOfPet { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public Owner PrevOwner { get; set; }

        public double Price { get; set; }



    }
}

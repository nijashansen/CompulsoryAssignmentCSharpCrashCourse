using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }

        public string name { get; set; }
        
        public Pet Pet { get; set; }
    }
}

using System;

namespace PetShop.UI.restAPI.DTO
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthday { get; set; }
    }
}
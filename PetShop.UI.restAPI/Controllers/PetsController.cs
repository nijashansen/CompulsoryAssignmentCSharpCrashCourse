using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationServices;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetShop.UI.restAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            try
            {
                return _petService.GetPets();
            }
            catch (Exception)
            {
                throw new Exception();
            }       
        }

        // GET api/pets/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return _petService.FindPetById(id);
        //}

        // POST api/pets
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petService.CreatePet(pet);
        }

        //whup


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            _petService.UpdatePet(pet);
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.Delete(id);
        }

    }
}
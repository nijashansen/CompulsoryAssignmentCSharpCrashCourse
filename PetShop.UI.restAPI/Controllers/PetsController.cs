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
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/Pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return Ok(_petService.GetPets());
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return Ok(_petService.GetPet(id));
        }

        // POST api/pet
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.CreatePet(pet));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/pet/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet updatedPet)
        {
            Pet petToUpdate = _petService.GetPet(id);
            return Ok(_petService.UpdatePet(petToUpdate, updatedPet));
        }

        // DELETE api/pet/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            Pet pet = _petService.GetPet(id);
            if (pet == null)
            {
                return BadRequest("Could not find pet to delete");
            }
            else
            {
                return Ok(_petService.DeletePet(pet));
            }
        }
    }
}
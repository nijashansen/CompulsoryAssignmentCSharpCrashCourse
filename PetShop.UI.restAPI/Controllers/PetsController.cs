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
            catch (Exception e)
            {
                return BadRequest($"Could not get any pets");
            }       
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var pet = _petService.FindPetById(id);
            if (pet == null || id <= 0)
            {
                return StatusCode(406, "Pet with id: " + id + ", Was not found.");
            }
            return pet;
            
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Name is Required to create a Pet");
            }
            else if (pet.PrevOwner == null)
            {
                return BadRequest("Previous Owner is Required to create a Pet");
            }


            return _petService.CreatePet(pet);
        }
        


        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.ID)
            {
                return BadRequest("Parameter id, and pet id must be the same!");
            }
            else if (pet.PrevOwner == null)
            {
                return BadRequest("Please enter an owner with an id");
            }
            else if (pet.PrevOwner.id != _petService.getOwner(pet).id)
            {
                return BadRequest("Previous Owner Parameter id, and Previous owner id, must be the same");
            }
            return Ok(_petService.UpdatePet(pet));
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.FindPetById(id);
            if (pet == null)
            {
                return StatusCode(404, "Could not find pet with id: " + id);
            }

            _petService.Delete(id);
            return Ok("Pet with id: " + id + ", Was deleted");
        }

    }
}
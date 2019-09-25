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
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.InfoPrPage == 0)
                {
                    return Ok(_petService.GetPets());
                }
                return Ok(_petService.GetFilteredPets(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.id)
            {
                return BadRequest("Parameter id and pet id must be the same");
            }

            _petService.UpdatePet(pet);
            return Ok();
        }

        // DELETE api/pet/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            Pet pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return BadRequest("Could not find pet to delete");
            }
            else
            {
                return Ok("Pet with id: " + pet.id + " Has been deleted");
            }
        }
    }
}
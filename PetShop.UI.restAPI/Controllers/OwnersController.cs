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
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                return _ownerService.GetOwners();
            }
            catch (Exception)
            {
                return BadRequest("No Owners Was Found");
            }
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            var owner = _ownerService.FindOwnerById(id);
            if (id <= 0 || owner == null)
            {
                return BadRequest("ID: " + id + ", does not exist\n" +
                    "Please enter a valid id");
            }
            return _ownerService.FindOwnerById(id);
        }

        // POST: api/Owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.name))
            {
                return BadRequest("Name is Required to create a Owner");
            }
            

            return _ownerService.CreateOwner(owner);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.id)
            {
                return BadRequest("Parameter id, and owner id must be the same!\n"
                    + "Please enter a owner with id, and name");
            }
            else if (owner.name == null)
            {
                return BadRequest("Owner has to have a name");
            }
            return Ok(_ownerService.UpdateOwner(owner));
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.FindOwnerById(id);
            if (owner == null)
            {
                return StatusCode(406, "Could not find owner with id: " + id);
            }

            _ownerService.Delete(id);
            return Ok("Owner with id: " + id + ", Was deleted");
        }
    }
}

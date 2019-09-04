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
                throw new Exception();
            }
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
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
                return BadRequest("Parameter id, and pet id must be the same!");
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
                return StatusCode(404, "Could not find owner with id: " + id);
            }

            _ownerService.Delete(id);
            return Ok("Owner with id: " + id + ", Was deleted");
        }
    }
}

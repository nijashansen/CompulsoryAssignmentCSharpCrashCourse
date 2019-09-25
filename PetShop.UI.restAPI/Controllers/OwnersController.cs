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
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/pet
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.InfoPrPage == 0)
                {
                    var list = _ownerService.GetOwners(null);
                    var newList = new List<Owner>();
                    foreach (var owner in list.List)
                    {
                        newList.Add(new Owner()
                        {
                            id = owner.id,
                            firstName = owner.firstName,
                            lastName = owner.lastName,
                            address = owner.address,
                            petHistory = owner.petHistory
                        });
                    }
                    var newFilteredList = new FilteringList<Owner>();
                    newFilteredList.List = newList;
                    newFilteredList.Count = list.Count;
                    return Ok(newFilteredList);
                }

                var fl = _ownerService.GetOwners(filter);

                return Ok(fl);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
            
        }

        // GET api/pet/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.GetOwner(id);
        }

        // POST api/pet
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            return _ownerService.CreateOwner(owner);
        }

        // PUT api/pet/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.id)
            {
                return BadRequest("Parameter id and owner id must be the same");
            }

            _ownerService.UpdateOwner(owner);
            return Ok();
        }

        // DELETE api/pet/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            Owner owner = _ownerService.DeleteOwner(id);
            if (owner == null)
            {
                return BadRequest("Parameter id must match owner id");
            }
            return Ok("Owner with id: " + id + " Was deleted");
            
        }
    }
}

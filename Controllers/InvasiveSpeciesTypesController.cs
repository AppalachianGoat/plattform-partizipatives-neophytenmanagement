using Microsoft.AspNetCore.Mvc;
using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InvasiveSpeciesTypesController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<InvasiveSpeciesType>> Get()
        {
            // TODO: Implement logic to retrieve all invasive species types from the database
            // and return them as a list of InvasiveSpeciesType objects.
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InvasiveSpeciesType speciesType)
        {
            // TODO: Implement logic to update the invasive species type with the given ID
            // in the database using the provided InvasiveSpeciesType object.
            return NoContent();
        }
    }
}

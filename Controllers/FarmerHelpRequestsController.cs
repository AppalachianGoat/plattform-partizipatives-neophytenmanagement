using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FarmerHelpRequestsController : ControllerBase
    {
        private readonly FarmHelperContext _context;

        public FarmerHelpRequestsController(FarmHelperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FarmerHelpRequest>> GetFarmerHelpRequests()
        {
            return _context.FarmerHelpRequests.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<FarmerHelpRequest> GetFarmerHelpRequest(int id)
        {
            var farmerHelpRequest = _context.FarmerHelpRequests.Find(id);

            if (farmerHelpRequest == null)
            {
                return NotFound();
            }

            return farmerHelpRequest;
        }

        [HttpPost]
        public ActionResult<FarmerHelpRequest> CreateFarmerHelpRequest(FarmerHelpRequest farmerHelpRequest)
        {
            _context.FarmerHelpRequests.Add(farmerHelpRequest);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFarmerHelpRequest), new { id = farmerHelpRequest.Id }, farmerHelpRequest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFarmerHelpRequest(int id, FarmerHelpRequest farmerHelpRequest)
        {
            if (id != farmerHelpRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(farmerHelpRequest).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFarmerHelpRequest(int id)
        {
            var farmerHelpRequest = _context.FarmerHelpRequests.Find(id);

            if (farmerHelpRequest == null)
            {
                return NotFound();
            }

            _context.FarmerHelpRequests.Remove(farmerHelpRequest);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
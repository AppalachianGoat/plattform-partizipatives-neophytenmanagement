using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plattform_partizipatives_neophytenmanagement.Data;
using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HelperHelpOffersController : ControllerBase
    {
        private readonly FarmerHelperMatchContext _context;

        public HelperHelpOffersController(FarmerHelperMatchContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HelperHelpOffer>> GetHelperHelpOffers()
        {
            var helperHelpOffers = _context.HelperHelpOffers.ToList();
            return Ok(helperHelpOffers);
        }

        [HttpGet("{id}")]
        public ActionResult<HelperHelpOffer> GetHelperHelpOffer(int id)
        {
            var helperHelpOffer = _context.HelperHelpOffers.Find(id);

            if (helperHelpOffer == null)
            {
                return NotFound();
            }

            return Ok(helperHelpOffer);
        }

        [HttpPost]
        public ActionResult<HelperHelpOffer> CreateHelperHelpOffer(HelperHelpOffer helperHelpOffer)
        {
            _context.HelperHelpOffers.Add(helperHelpOffer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHelperHelpOffer), new { id = helperHelpOffer.Id }, helperHelpOffer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHelperHelpOffer(int id, HelperHelpOffer helperHelpOffer)
        {
            if (id != helperHelpOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(helperHelpOffer).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHelperHelpOffer(int id)
        {
            var helperHelpOffer = _context.HelperHelpOffers.Find(id);

            if (helperHelpOffer == null)
            {
                return NotFound();
            }

            _context.HelperHelpOffers.Remove(helperHelpOffer);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
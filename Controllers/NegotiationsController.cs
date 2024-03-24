using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plattform_partizipatives_neophytenmanagement.Data;
using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NegotiationsController : ControllerBase
    {
        private readonly FarmerHelperMatchContext _context;

        public NegotiationsController(FarmerHelperMatchContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negotiation>>> GetNegotiations()
        {
            return await _context.Negotiations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Negotiation>> GetNegotiation(int id)
        {
            var negotiation = await _context.Negotiations.FindAsync(id);

            if (negotiation == null)
            {
                return NotFound();
            }

            return negotiation;
        }

        [HttpPost]
        public async Task<ActionResult<Negotiation>> CreateNegotiation(Negotiation negotiation)
        {
            _context.Negotiations.Add(negotiation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNegotiation), new { id = negotiation.Id }, negotiation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNegotiation(int id, Negotiation negotiation)
        {
            if (id != negotiation.Id)
            {
                return BadRequest();
            }

            _context.Entry(negotiation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegotiationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNegotiation(int id)
        {
            var negotiation = await _context.Negotiations.FindAsync(id);
            if (negotiation == null)
            {
                return NotFound();
            }

            _context.Negotiations.Remove(negotiation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NegotiationExists(int id)
        {
            return _context.Negotiations.Any(e => e.Id == id);
        }
    }
}
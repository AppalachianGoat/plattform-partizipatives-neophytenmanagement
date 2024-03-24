using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plattform_partizipatives_neophytenmanagement.Data;
using plattform_partizipatives_neophytenmanagement.Models;
using plattform_partizipatives_neophytenmanagement.Services;
using plattform_partizipatives_neophytenmanagement.Utils; // Add the appropriate namespace for FarmerHelpRequest and FarmerHelperMatchContext


namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FarmerHelpRequestsController : ControllerBase
    {
        private readonly FarmerHelperMatchContext _context;
        private readonly IMapper _mapper;

        public FarmerHelpRequestsController(FarmerHelperMatchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("get")]
        public async Task<ActionResult<IEnumerable<FarmerHelpRequest>>> GetFarmerHelpRequests(FilterFarmerHelpRequestDto filterDto)
        {

            var filter_location = await _context.Locations.FirstAsync(l =>
                l.LocationString == filterDto.Location);

            var filteredResults = _context.FarmerHelpRequests
                .Include(f => f.Location)
                .AsEnumerable()
                .Where(f =>
                    GeographyUtils.DistanceBetweenLocations(
                        f.Location.Latitude,
                        f.Location.Longitude,
                        filter_location.Latitude,
                        filter_location.Longitude)
                    <= filterDto.DistanceFromLocation)
                .Where(f => f.WorkVolume >= filterDto.WorkVolume)
                .Where(f => f.NumberOfHelpers >= filterDto.NumberOfHelpers)
                .Where(f => f.StartDate >= filterDto.StartDate && f.EndDate <= filterDto.EndDate);

            return filteredResults.ToList();
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

        [HttpPost("create")]
        public ActionResult<FarmerHelpRequest> CreateFarmerHelpRequest(CreateFarmerHelpRequestDto farmerHelpRequestDto)
        {
            var user = _context.Users.Find(farmerHelpRequestDto.OwnerUserId);
            if (user is null)
            {
                return BadRequest("User with the provided OwnerUserId does not exist.");
            }

            var farmerHelpRequest = _mapper.Map<FarmerHelpRequest>(farmerHelpRequestDto);
            farmerHelpRequest.OwnerUser = user;

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
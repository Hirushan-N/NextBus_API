using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextBus_API.Configs;
using NextBus_API.Data;
using NextBus_API.Models.DTO;
using NextBus_API.Models.Entities;

namespace NextBus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusOwnerController : ControllerBase
    {
        private readonly NextBusDbContext nextBusDbContext;

        public BusOwnerController(NextBusDbContext nextBusDbContext)
        {
            this.nextBusDbContext = nextBusDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusOwners()
        {
            var busOwners = await nextBusDbContext.BusOwners.ToListAsync();

            return Ok(busOwners);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBusOwnerById(Guid id)
        {
            var busOwner = await nextBusDbContext.BusOwners.FirstOrDefaultAsync(x => x.Id == id);

            if (busOwner != null)
            {
                return Ok(busOwner);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{busOwnerCode}")]
        public async Task<IActionResult> GetBusOwnerByCode(String busOwnerCode)
        {
            var busOwner = await nextBusDbContext.BusOwners.FirstOrDefaultAsync(x => x.BusOwnerCode == busOwnerCode);

            if (busOwner != null)
            {
                return Ok(busOwner);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddBusOwner(AddBusOwnerRequest addBusOwnerRequest)
        {
            // Convert DTO to Entity

            var busOwner = new BusOwner()
            {
                Name = addBusOwnerRequest.Name,
                NIC = addBusOwnerRequest.NIC,
                Mobile1 = addBusOwnerRequest.Mobile1,
                Mobile2 = addBusOwnerRequest.Mobile2,
                Mobile3 = addBusOwnerRequest.Mobile3,
                Email = addBusOwnerRequest.Email,
                RegDate = addBusOwnerRequest.RegDate,
                ServiceName = addBusOwnerRequest.ServiceName,
                NoOfBuses = addBusOwnerRequest.NoOfBuses
            };

            busOwner.Id = Guid.NewGuid();
            busOwner.BusOwnerCode = CodeMaster.GenerateCode("BOC");

            await nextBusDbContext.BusOwners.AddAsync(busOwner);
            await nextBusDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBusOwnerById), new { id = busOwner.Id }, busOwner);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBusOwner([FromRoute] Guid id, UpdateBusOwnerRequest updateBusOwnerRequest)
        {
            // Check if exists

            var existsBusOwner = await nextBusDbContext.BusOwners.FindAsync(id);

            if (existsBusOwner != null)
            {
                existsBusOwner.Name = updateBusOwnerRequest.Name;
                existsBusOwner.NIC = updateBusOwnerRequest.NIC;
                existsBusOwner.Mobile1 = updateBusOwnerRequest.Mobile1;
                existsBusOwner.Mobile2 = updateBusOwnerRequest.Mobile2;
                existsBusOwner.Mobile3 = updateBusOwnerRequest.Mobile3;
                existsBusOwner.Email = updateBusOwnerRequest.Email;
                existsBusOwner.RegDate = updateBusOwnerRequest.RegDate;
                existsBusOwner.ServiceName = updateBusOwnerRequest.ServiceName;
                existsBusOwner.NoOfBuses = updateBusOwnerRequest.NoOfBuses;

                await nextBusDbContext.SaveChangesAsync();

                return Ok(existsBusOwner);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBusOwner(Guid id)
        {
            var existsBusOwner = await nextBusDbContext.BusOwners.FindAsync(id);

            if (existsBusOwner != null)
            {
                nextBusDbContext.Remove(existsBusOwner);
                await nextBusDbContext.SaveChangesAsync();

                return Ok(existsBusOwner);
            }

            return NotFound();
        }
    }
}

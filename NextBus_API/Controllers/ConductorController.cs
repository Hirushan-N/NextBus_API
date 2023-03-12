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
    public class ConductorController : ControllerBase
    {
        private readonly NextBusDbContext nextBusDbContext;

        public ConductorController(NextBusDbContext nextBusDbContext)
        {
            this.nextBusDbContext = nextBusDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConductors()
        {
            var conductors = await nextBusDbContext.Conductors.ToListAsync();

            return Ok(conductors);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetConductorById(Guid id)
        {
            var conductor = await nextBusDbContext.Conductors.FirstOrDefaultAsync(x => x.Id == id);

            if (conductor != null)
            {
                return Ok(conductor);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{conductorCode}")]
        public async Task<IActionResult> GetConductorByCode(string conductorCode)
        {
            var conductor = await nextBusDbContext.Conductors.FirstOrDefaultAsync(x => x.ConductorCode == conductorCode);

            if (conductor != null)
            {
                return Ok(conductor);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddConductor(AddConductorRequest addConductorRequest, string? busOwnerCode)
        {
            // Convert DTO to Entity

            var conductor = new Conductor()
            {
                Name = addConductorRequest.Name,
                NIC = addConductorRequest.NIC,
                Mobile1 = addConductorRequest.Mobile1,
                Mobile2 = addConductorRequest.Mobile2,
                Mobile3 = addConductorRequest.Mobile3,
                Email = addConductorRequest.Email,
                RegDate = addConductorRequest.RegDate
            };

            conductor.Id = Guid.NewGuid();
            conductor.ConductorCode = CodeMaster.GenerateCode("CDC");
            var BusOwner = await nextBusDbContext.BusOwners.FirstOrDefaultAsync(x => x.BusOwnerCode == busOwnerCode);

            if (BusOwner != null)
            {
                conductor.BusOwner = BusOwner;
            }
            else
            {
                return BadRequest("Bus Owner Code is invalid..");
            }

            await nextBusDbContext.Conductors.AddAsync(conductor);
            await nextBusDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConductorById), new { id = conductor.Id }, conductor);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateConductor([FromRoute] Guid id, UpdateConductorRequest updateConductorRequest)
        {
            // Check if exists

            var existsConductor = await nextBusDbContext.Conductors.FirstOrDefaultAsync(x => x.Id == id);

            if (existsConductor != null)
            {
                existsConductor.Name = updateConductorRequest.Name;
                existsConductor.NIC = updateConductorRequest.NIC;
                existsConductor.Mobile1 = updateConductorRequest.Mobile1;
                existsConductor.Mobile2 = updateConductorRequest.Mobile2;
                existsConductor.Mobile3 = updateConductorRequest.Mobile3;
                existsConductor.Email = updateConductorRequest.Email;
                existsConductor.RegDate = updateConductorRequest.RegDate;

                await nextBusDbContext.SaveChangesAsync();

                return Ok(existsConductor);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteConductor(Guid id)
        {
            var existsConductor = await nextBusDbContext.Conductors.FirstOrDefaultAsync(x => x.Id == id);

            if (existsConductor != null)
            {
                nextBusDbContext.Remove(existsConductor);
                await nextBusDbContext.SaveChangesAsync();

                return Ok(existsConductor);
            }

            return NotFound();
        }
    }
}

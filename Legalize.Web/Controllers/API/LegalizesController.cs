using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Legalize.Web.Data;
using Legalize.Web.Data.Entities;

namespace Legalize.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalizesController : ControllerBase
    {
        private readonly DataContext _context;

        public LegalizesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Legalizes
        [HttpGet]
        public IEnumerable<LegalizeEntity> GetLegalizes()
        {
            return _context.Legalizes;
        }

        // GET: api/Legalizes/5
        [HttpGet("{Employee}")]
        public async Task<IActionResult> GetLegalizeEntity([FromRoute] string Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LegalizeEntity legalizeEntity = await _context.Legalizes
                .Include(t => t.Trips)
                .ThenInclude(t => t.TripDetails)
                .Include(t => t.Trips)
                .FirstOrDefaultAsync(e => e.EmployeeId == Employee);

            if (legalizeEntity == null)
            {
                return NotFound();
            }

            return Ok(legalizeEntity);
        }

        
    }
}
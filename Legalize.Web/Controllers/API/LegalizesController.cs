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

            var legalizeEntity = await _context.Legalizes.FirstOrDefaultAsync(e => e.EmployeeId == Employee);

            if (legalizeEntity == null)
            {
                return NotFound();
            }

            return Ok(legalizeEntity);
        }

        
    }
}
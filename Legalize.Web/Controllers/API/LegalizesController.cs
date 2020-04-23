using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Legalize.Web.Helpers;

namespace Legalize.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalizesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public LegalizesController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        // GET: api/Legalizes/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLegalizeEntity([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LegalizeEntity legalizeEntity = await _context.Legalizes
                .Include(t => t.Trips)
                .Include(t => t.User)
                .Include(t => t.City)
                .Include(t => t.Trips)
                .ThenInclude(t => t.ExpenseType)
                .FirstOrDefaultAsync(l => l.Id == Id);

            if (legalizeEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToLegalizeResponse(legalizeEntity));
        }

        
    }
}
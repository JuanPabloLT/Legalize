﻿using System;
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
        [HttpGet("{Employee}")]
        public async Task<IActionResult> GetLegalizeEntity([FromRoute] string Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LegalizeEntity legalizeEntity = await _context.Legalizes
                .Include(l => l.Trips)
                .ThenInclude(l => l.TripDetails)
                .Include(l => l.Trips)
                .FirstOrDefaultAsync(l => l.EmployeeId == Employee);

            if (legalizeEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToTripResponse(legalizeEntity));
        }

        
    }
}
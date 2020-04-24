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
using Legalize.Common.Models;
using System.Globalization;
using Legalize.Web.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Legalize.Web.Controllers.API
{
    
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LegalizesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IUserHelper _userHelper;
        private readonly ICitierHelper _citierHelper;

        public LegalizesController(DataContext context
            ,IConverterHelper converterHelper
            ,IUserHelper userHelper
            ,ICitierHelper citierHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _userHelper = userHelper;
            _citierHelper = citierHelper;

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

        // GET: api/Legalizes/GetLegalizeEntity
        [HttpGet]
        [Route("GetLegalizeEntity")]
        public async Task<IActionResult> GetLegalizeEntity()
        {
            List<LegalizeEntity> legalizes = await _context.Legalizes
                .Include(t => t.Trips)
                .Include(t => t.User)
                .Include(t => t.City)
                .Include(t => t.Trips)
                .ThenInclude(t => t.ExpenseType)
                .ToListAsync();
            return Ok(_converterHelper.ToLegalizeResponse(legalizes));
        }

        // POST: api/Legalizes/PostLegalizeEntity
        [HttpPost]
        [Route("PostLegalizeEntity")]
        public async Task<IActionResult> PostLegalizeEntity([FromBody] LegalizeRequest legalizeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CultureInfo cultureInfo = new CultureInfo(legalizeRequest.CultureInfo);
            Resource.Culture = cultureInfo;

            UserEntity userEntity = await _userHelper.GetUserAsync(legalizeRequest.UserId);
            if (userEntity == null)
            {
                return BadRequest(Resource.UserDoesntExists);
            }

            CityEntity cityEntity = await _citierHelper.GetCityAsync(legalizeRequest.City);
            if (cityEntity == null)
            {
                return BadRequest(Resource.CityDoesntExists);
            }

            LegalizeEntity legalizeEntity = new LegalizeEntity
            {
                StartDate = legalizeRequest.StartDate,
                EndDate = legalizeRequest.EndDate,
                City = cityEntity,
                User = userEntity
            };

            _context.Legalizes.Add(legalizeEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }



}

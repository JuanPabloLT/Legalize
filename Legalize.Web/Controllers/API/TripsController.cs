using Legalize.Common.Models;
using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Legalize.Web.Helpers;
using Legalize.Web.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly ILegalizeHelper _legalizeHelper;
        private readonly IExpenseTyperHelper _expenseTyperHelper;

        public TripsController(DataContext context,
            IUserHelper userHelper,
            IConverterHelper converterHelper,
            ILegalizeHelper legalizeHelper,
            IExpenseTyperHelper expenseTyperHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
            _legalizeHelper = legalizeHelper;
            _expenseTyperHelper = expenseTyperHelper;
        }

        // POST: api/Trips/
        [HttpPost]
        public async Task<IActionResult> PostTripEntity([FromBody] TripRequest tripRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CultureInfo cultureInfo = new CultureInfo(tripRequest.CultureInfo);
            Resource.Culture = cultureInfo;

            LegalizeEntity legalizeEntity = await _legalizeHelper.GetLegalizeAsync(tripRequest.LegalizeId);
            if (legalizeEntity == null)
            {
                return BadRequest(Resource.LegalizeDoesntExists);
            }

            ExpenseTypeEntity expenseTypeEntity = await _expenseTyperHelper.GetExpenseTypeAsync(tripRequest.ExpenseType);
            if (expenseTypeEntity == null)
            {
                return BadRequest(Resource.ExpenseTypeDoesntExists);
            }

            TripEntity tripEntity = new TripEntity
            {
                Date = tripRequest.Date,
                Amount = tripRequest.Amount ,
                Description = tripRequest.Description,
                PicturePath = tripRequest.PicturePath,
                Legalize = legalizeEntity,
                ExpenseType = expenseTypeEntity
            };

            _context.Trips.Add(tripEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}



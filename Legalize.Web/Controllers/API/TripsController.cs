using Legalize.Common.Models;
using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Legalize.Web.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public TripsController(DataContext context,
            IUserHelper userHelper,
            IConverterHelper converterHelper,
            ILegalizeHelper legalizeHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
            _legalizeHelper = legalizeHelper;
        }


        /*[HttpPost]
        [Route("GetTripsForUser")]
        public async Task<IActionResult> PostTripEntity([FromBody] TripForUserRequest Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserEntity userEntity = await _userHelper.GetUserAsync(tripRequest.User);

            if (userEntity == null)
            {
                return BadRequest("User doesn't exists.");
            }

            TripEntity tripEntity = new TripEntity
            {
 
                Date = DateTime.UtcNow,
                Amount = tripRequest.Amount,
                Description = tripRequest.Description,
                PicturePath = tripRequest.PicturePath,

            };

            _context.Trips.Add(tripEntity);
            await _context.SaveChangesAsync();
            return Ok(_converterHelper.ToTripResponse(tripEntity));
        }*/
    }
}

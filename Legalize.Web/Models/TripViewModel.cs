using Legalize.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Models
{
    public class TripViewModel : TripEntity
    {
        [Display(Name = "Picture")]
        public IFormFile TripPicture { get; set; }
    }
}

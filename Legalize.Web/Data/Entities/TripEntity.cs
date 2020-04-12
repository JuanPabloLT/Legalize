using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Data.Entities
{
    public class TripEntity
    {
        public int id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime? EndDate { get; set; }

        public UserEntity User { get; set; }
        public CityEntity City { get; set; }

        [Display(Name = "Total Amount")]
        public int TotalAmount { get; set; }


        public ICollection<TripDetailEntity> TripDetails { get; set; }

    }
}

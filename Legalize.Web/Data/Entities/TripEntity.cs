using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Data.Entities
{
    public class TripEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Local")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime DateLocal => Date.ToLocalTime();

        public int Amount { get; set; }
        public string Description { get; set; }

        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        public LegalizeEntity Legalize { get; set; }

        [Display(Name = "ExpenseType")]
        public ExpenseTypeEntity ExpenseType { get; set; }



    }
}

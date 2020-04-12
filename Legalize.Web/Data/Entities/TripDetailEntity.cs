using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Legalize.Web.Data.Entities
{
    public class TripDetailEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        public TripEntity Trip { get; set; }

        [Display(Name = "ExpenseType")]
        public ExpenseTypeEntity ExpenseType { get; set; }



    }
}

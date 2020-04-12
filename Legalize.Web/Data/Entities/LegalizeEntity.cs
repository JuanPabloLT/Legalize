using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Data.Entities
{
    public class LegalizeEntity
    {
        public int Id { get; set; }

       
        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }
    }
}

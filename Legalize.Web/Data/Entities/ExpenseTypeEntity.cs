using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Legalize.Web.Data.Entities
{
    public class ExpenseTypeEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

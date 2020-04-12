using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Legalize.Web.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CityEntity> Cities { get; set; }
    }
}

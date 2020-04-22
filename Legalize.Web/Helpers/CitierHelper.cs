using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public class CitierHelper : ICitierHelper
    {
        public  async Task<CityEntity> AddCityAsync(string name)
        {
            CityEntity city = new CityEntity
            {
                Name = name,
            };
            return city;
        }
    }
}

using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public interface ICitierHelper
    {
        Task<CityEntity> AddCityAsync(String name);
    }
}

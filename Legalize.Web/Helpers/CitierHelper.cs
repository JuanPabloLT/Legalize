using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public class CitierHelper : ICitierHelper
    {
        private readonly DataContext _context;
        public CitierHelper(DataContext context)
        {
            _context = context;
        }
        public  async Task<CityEntity> AddCityAsync(string name)
        {
            CityEntity city = new CityEntity
            {
                Name = name,
            };
            return await Task.FromResult(city);
        }

        public async Task<CityEntity> GetCityAsync(int Id)
        {
            CityEntity cityEntity = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == Id);
            return cityEntity;
        }
    }
}

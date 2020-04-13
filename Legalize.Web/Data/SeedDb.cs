using Legalize.Web.Data.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckLegalizeAsync();
        }

        private async Task CheckLegalizeAsync()
        {
            if (_dataContext.Legalizes.Any())
            {
                return;
            }

            _dataContext.Legalizes.Add(new LegalizeEntity
            {
                EmployeeId = "1020475226",
                Trips = new List<TripEntity>
                {
                    new TripEntity
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(5),
                        TotalAmount = 500000,

                        TripDetails = new List<TripDetailEntity>{
                        new TripDetailEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 24000,
                            Description = "Hotel",
                            PicturePath = "Localhost", 
                        }
                        }
                    },

                    new TripEntity
                    {
                        StartDate = DateTime.UtcNow.AddDays(10),
                        EndDate = DateTime.UtcNow.AddDays(15),
                        TotalAmount = 700000,

                        TripDetails = new List<TripDetailEntity>{
                        new TripDetailEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 50000,
                            Description = "Comida",
                            PicturePath = "Localhost",
                        }
                        }
                    }
                 }
             });
        }
    }
}

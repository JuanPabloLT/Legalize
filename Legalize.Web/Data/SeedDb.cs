using Legalize.Common.Enums;
using Legalize.Web.Data.Entities;
using Legalize.Web.Helpers;
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
        private readonly IUserHelper _userHelper;
        private readonly ICitierHelper _citierHelper;

        public SeedDb(
            DataContext dataContext,
            IUserHelper userHelper,
            ICitierHelper citierHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _citierHelper = citierHelper;
        }


        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Londono", "pablo18970@gmail.com", "319 627 1487", UserType.Admin);
            UserEntity Employee = await CheckUserAsync("2020", "Juan", "Londono", "pablo18970@hotmail.com", "319 627 1487", UserType.Employee);
            CityEntity City1 = await _citierHelper.AddCityAsync("Medellín");
            CityEntity City2 = await _citierHelper.AddCityAsync("Bogotá");
            CityEntity City3 = await _citierHelper.AddCityAsync("Cali");
            CityEntity City4 = await _citierHelper.AddCityAsync("Pasto");
            await CheckLegalizeAsync(Employee, City1, City2, City3, City4);
            await CheckExpenseTypeAsync();
            
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Employee.ToString());

        }


        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                /*var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);*/
            }

            return user;
        }


        
        private async Task CheckLegalizeAsync(UserEntity Employee,
            CityEntity City1,
            CityEntity City2,
            CityEntity City3,
            CityEntity City4)
        {
            if (!_dataContext.Legalizes.Any())
            {
                _dataContext.Legalizes.Add(new LegalizeEntity
                {
                    EmployeeId = "1020482663",
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddDays(5),
                            TotalAmount = 500000,
                            City = City1,
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow.AddDays(10),
                            EndDate = DateTime.UtcNow.AddDays(15),
                            TotalAmount = 700000,
                            City = City2,
                        }
                    }
                });

                _dataContext.Legalizes.Add(new LegalizeEntity
                {
                    EmployeeId = "1020489293",
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow.AddDays(20),
                            EndDate = DateTime.UtcNow.AddDays(25),
                            TotalAmount = 100000,
                            City = City3,
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow.AddDays(30),
                            EndDate = DateTime.UtcNow.AddDays(35),
                            TotalAmount = 800000,
                            City = City4,
                        }
                    }
                });

                await _dataContext.SaveChangesAsync();
            }
        }


        private async Task CheckExpenseTypeAsync()
        {
            if (!_dataContext.ExpenseTypes.Any())
            {
                _dataContext.ExpenseTypes.Add(new ExpenseTypeEntity
                {
                    Name = "Estancia",

                });

                _dataContext.ExpenseTypes.Add(new ExpenseTypeEntity
                {
                    Name = "Manutención",

                });

                _dataContext.ExpenseTypes.Add(new ExpenseTypeEntity
                {
                    Name = "Locomoción",

                });

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}

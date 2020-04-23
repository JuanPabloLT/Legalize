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
        private readonly IExpenseTyperHelper _expenseTyperHelper;

        public SeedDb(
            DataContext dataContext,
            IUserHelper userHelper,
            ICitierHelper citierHelper,
            IExpenseTyperHelper expenseTyperHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _citierHelper = citierHelper;
            _expenseTyperHelper = expenseTyperHelper;
        }


        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Londono", "pablo18970@gmail.com", "319 627 1487", UserType.Admin);
            UserEntity Employee = await CheckUserAsync("2020", "Juan", "Londono", "pablo18970@hotmail.com", "319 627 1487", UserType.Employee);
            UserEntity Employee2 = await CheckUserAsync("3030", "Juan", "Londono", "pablo18972@hotmail.com", "300 842 3521", UserType.Employee);
            ExpenseTypeEntity Expense1 = await _expenseTyperHelper.AddExpenseTypeAsync("Estancia");
            ExpenseTypeEntity Expense2 = await _expenseTyperHelper.AddExpenseTypeAsync("Manutención");
            ExpenseTypeEntity Expense3 = await _expenseTyperHelper.AddExpenseTypeAsync("Locomoción");
            CityEntity City1 = await _citierHelper.AddCityAsync("Medellín");
            CityEntity City2 = await _citierHelper.AddCityAsync("Bogotá");
            CityEntity City3 = await _citierHelper.AddCityAsync("Cali");
            CityEntity City4 = await _citierHelper.AddCityAsync("Pasto");
            await CheckLegalizeAsync(Employee, Employee2, City1, City2, City3, City4);
            //await CheckExpenseTypeAsync();
            
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
            var user = await _userHelper.GetUserAsync(email);
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
            UserEntity Employee2,
            CityEntity City1,
            CityEntity City2,
            CityEntity City3,
            CityEntity City4)
        {
            if (!_dataContext.Legalizes.Any())
            {
                _dataContext.Legalizes.Add(new LegalizeEntity
                {
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(10),
                    TotalAmount = 700000,
                    City = City1,
                    User = Employee,
                });

                _dataContext.Legalizes.Add(new LegalizeEntity
                {
                    StartDate = DateTime.UtcNow.AddDays(15),
                    EndDate = DateTime.UtcNow.AddDays(20),
                    TotalAmount = 800000,
                    City = City2,
                    User = Employee2,
                });

                await _dataContext.SaveChangesAsync();
            }
        }


        /*private async Task CheckExpenseTypeAsync()
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
        }*/
    }
}

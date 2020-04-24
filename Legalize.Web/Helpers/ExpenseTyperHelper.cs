using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public class ExpenseTyperHelper : IExpenseTyperHelper
    {
        private readonly DataContext _context;
        public ExpenseTyperHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<ExpenseTypeEntity> AddExpenseTypeAsync(string name)
        {
            ExpenseTypeEntity ExpenseType = new ExpenseTypeEntity
            {
                Name = name,
            };
            return await Task.FromResult(ExpenseType);
        }

        public async Task<ExpenseTypeEntity> GetExpenseTypeAsync(int Id)
        {
            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes
                .FirstOrDefaultAsync(m => m.Id == Id);
            return expenseTypeEntity;
        }

    }
}

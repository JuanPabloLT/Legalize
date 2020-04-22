using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public class ExpenseTyperHelper : IExpenseTyperHelper
    {
        public async Task<ExpenseTypeEntity> AddExpenseTypeAsync(string name)
        {
            ExpenseTypeEntity ExpenseType = new ExpenseTypeEntity
            {
                Name = name,
            };
            return await Task.FromResult(ExpenseType);
        }

    }
}

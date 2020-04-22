using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public interface IExpenseTyperHelper
    {
        Task<ExpenseTypeEntity> AddExpenseTypeAsync(string name);
    }
}

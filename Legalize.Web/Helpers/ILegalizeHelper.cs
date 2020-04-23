using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public interface ILegalizeHelper
    {
        Task<LegalizeEntity> GetLegalizeAsync(int EmployeeId);
    }
    
}

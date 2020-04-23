using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public class LegalizeHelper : ILegalizeHelper
    {
        private readonly DataContext _context;
        public LegalizeHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<LegalizeEntity> GetLegalizeAsync(int Id)
        {
            LegalizeEntity legalizeEntity = await _context.Legalizes
                .FirstOrDefaultAsync(m => m.Id == Id);
            return legalizeEntity;
        }
    }
}

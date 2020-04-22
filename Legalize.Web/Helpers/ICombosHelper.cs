using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRoles();
        IEnumerable<SelectListItem> GetComboExpenseType();
        IEnumerable<SelectListItem> GetComboCity();
    }
}

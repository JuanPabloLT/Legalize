using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboRoles()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "[Select a role...]" },
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "Employee" }
            };

            return list;
        }

        public IEnumerable<SelectListItem> GetComboExpenseType()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "[Select expense type...]" },
                new SelectListItem { Value = "1", Text = "Estancia" },
                new SelectListItem { Value = "1", Text = "Manutención" },
                new SelectListItem { Value = "2", Text = "Locomoción" }
            };

            return list;
        }
    }
}

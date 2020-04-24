using Legalize.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Legalize.Prism.Helpers
{
    public static class CombosHelper
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role { Id = 1, Name = Languages.Admin },
                new Role { Id = 2, Name = Languages.Employe }
            };
        }
    }


}

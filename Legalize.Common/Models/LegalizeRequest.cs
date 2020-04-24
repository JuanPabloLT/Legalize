using System;
using System.Collections.Generic;
using System.Text;

namespace Legalize.Common.Models
{
    public class LegalizeRequest
    {
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }
        public int City { get; set; }
        public Guid UserId { get; set; }
        public string CultureInfo { get; set; }

    }
}

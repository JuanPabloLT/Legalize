using System;
using System.Collections.Generic;
using System.Text;

namespace Legalize.Common.Models
{
    public class LegalizeResponse
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }

        public List<TripResponse> Trips { get; set; }
        public UserResponse User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legalize.Common.Models
{
    public  class TripResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal => StartDate.ToLocalTime();
        public DateTime? EndDate { get; set; }
        public DateTime? EndDateLocal => EndDate?.ToLocalTime();
        public int TotalAmount { get; set; }
        public string City { get; set; }
        public int TotalAmountTrip => TripDetails == null ? 0 : TripDetails.Sum(t => t.Amount);

        public List<TripDetailResponse> TripDetails { get; set; }
        public UserResponse User { get; set; }

    }
}

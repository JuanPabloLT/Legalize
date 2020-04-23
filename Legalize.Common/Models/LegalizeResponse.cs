using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legalize.Common.Models
{
    public class LegalizeResponse
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal => StartDate.ToLocalTime();
        public DateTime EndDate { get; set; }
        public DateTime EndDateLocal => EndDate.ToLocalTime();
        public int TotalAmount { get; set; }
        public CityResponse City { get; set; }
        public int TotalAmountTrip => Trips == null ? 0 : Trips.Sum(t => t.Amount);
        public List<TripResponse> Trips { get; set; }
        public UserResponse User { get; set; }
        public int NumberOfTrips => Trips == null ? 0 : Trips.Count;

    }
}

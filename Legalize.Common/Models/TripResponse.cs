using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legalize.Common.Models
{
    public  class TripResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateLocal => Date.ToLocalTime();
        public int Amount { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }

    }
}

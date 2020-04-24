using System;
using System.Collections.Generic;
using System.Text;

namespace Legalize.Common.Models
{
    public class TripRequest
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public int ExpenseType { get; set; }
        public int LegalizeId { get; set; }
        public string CultureInfo { get; set; }

    }
}

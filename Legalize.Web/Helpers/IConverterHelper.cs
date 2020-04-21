﻿using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legalize.Common.Models;

namespace Legalize.Web.Helpers
{
    public interface IConverterHelper
    {
        LegalizeResponse ToLegalizeResponse(LegalizeEntity legalize);
        LegalizeResponse ToTripResponse(LegalizeEntity legalize);
        CityResponse ToCityResponse(CityEntity city);
    }
}

using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Legalize.Common.Models;

namespace Legalize.Web.Helpers
{
    interface IConverterHelper
    {
        LegalizeResponse ToLegalizeResponse(LegalizeEntity legalizeEntity);
    }
}

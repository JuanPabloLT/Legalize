using Legalize.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legalize.Common.Models;
using Legalize.Web.Models;

namespace Legalize.Web.Helpers
{
    public interface IConverterHelper
    {
        LegalizeResponse ToLegalizeResponse2(LegalizeEntity legalize);
        LegalizeResponse ToLegalizeResponse(LegalizeEntity legalize);
        List <LegalizeResponse> ToLegalizeResponse(List<LegalizeEntity> legalizeEntities);
        TripResponse ToTripResponse(TripEntity trip);
        CityResponse ToCityResponse(CityEntity city);
        UserResponse ToUserResponse(UserEntity user);
        TripEntity ToTipEntity(TripViewModel tripViewModel, string path, bool isNew);
        TripViewModel ToTripViewModel(TripEntity tripEntity);
        ExpenseTypeResponse ToExpenseTypeResponse(ExpenseTypeEntity expense);

    }
}

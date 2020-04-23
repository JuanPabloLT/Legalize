using Legalize.Common.Models;
using Legalize.Web.Data.Entities;
using System.Linq;


namespace Legalize.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public LegalizeResponse ToLegalizeResponse2(LegalizeEntity legalize)
        {
            return new LegalizeResponse
            {
                Id = legalize.Id,
                StartDate = legalize.StartDate ,
                EndDate = legalize.EndDate,
                TotalAmount = legalize.TotalAmount,
                City = ToCityResponse(legalize.City),
                User = ToUserResponse(legalize.User),

            };
        }

        public LegalizeResponse ToLegalizeResponse(LegalizeEntity legalizeEntity)
        {
            return new LegalizeResponse
            {
                Id = legalizeEntity.Id,
                StartDate = legalizeEntity.StartDate,
                EndDate = legalizeEntity.EndDate,
                TotalAmount = legalizeEntity.TotalAmount,
                City = ToCityResponse(legalizeEntity.City),
                User = ToUserResponse(legalizeEntity.User),
                Trips = legalizeEntity.Trips?.Select(tr => new TripResponse
                {
                    Id = tr.Id,
                    Date = tr.Date,
                    Amount = tr.Amount,
                    Description = tr.Description,
                    PicturePath = tr.PicturePath,
                }).ToList(),
            };
        }

        public TripResponse ToTripResponse(TripEntity tripEntity)
        {
            return new TripResponse
            {

                Id = tripEntity.Id,
                Date = tripEntity.Date,
                Amount = tripEntity.Amount,
                Description = tripEntity.Description,
                PicturePath = tripEntity.PicturePath,
  
            };
        }

        public UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PicturePath = user.PicturePath,
                UserType = user.UserType
            };
        }

        public CityResponse ToCityResponse(CityEntity city)
        {
            if (city == null)
            {
                return null;
            }

            return new CityResponse
            {
                Name = city.Name,
            };
        }



    }
}

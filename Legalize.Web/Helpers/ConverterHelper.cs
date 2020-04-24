using Legalize.Common.Models;
using Legalize.Web.Data.Entities;
using Legalize.Web.Models;
using System.Collections.Generic;
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
                City = ToCityResponse(legalizeEntity.City),
                User = ToUserResponse(legalizeEntity.User),
                Trips = legalizeEntity.Trips?.Select(tr => new TripResponse
                {
                    Id = tr.Id,
                    Date = tr.Date,
                    Amount = tr.Amount,
                    Description = tr.Description,
                    PicturePath = tr.PicturePath,
                    ExpenseType = ToExpenseTypeResponse(tr.ExpenseType),
                }).ToList(),
            };
        }

        public List<LegalizeResponse> ToLegalizeResponse(List<LegalizeEntity> legalizeEntities)
        {
            List<LegalizeResponse> list = new List<LegalizeResponse>();
            foreach (LegalizeEntity legalizeEntity in legalizeEntities)
            {
                list.Add(ToLegalizeResponse(legalizeEntity));
            }
            return list;
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
                ExpenseType = ToExpenseTypeResponse(tripEntity.ExpenseType),
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

        public ExpenseTypeResponse ToExpenseTypeResponse(ExpenseTypeEntity expense)
        {
            if (expense == null)
            {
                return null;
            }

            return new ExpenseTypeResponse
            {
                Name = expense.Name,
            };
        }

        public TripEntity ToTipEntity(TripViewModel tripViewModel, string path, bool isNew)
        {
            return new TripEntity
            {
                Id = isNew ? 0 : tripViewModel.Id,
                PicturePath = path,
                Date = tripViewModel.Date,
                Amount = tripViewModel.Amount,
                Description = tripViewModel.Description,
                ExpenseType = tripViewModel.ExpenseType,
            };
        }

        public TripViewModel ToTripViewModel(TripEntity tripEntity)
        {
            return new TripViewModel
            {
                Id = tripEntity.Id,
                PicturePath = tripEntity.PicturePath,
                Date = tripEntity.Date,
                Amount = tripEntity.Amount,
                Description = tripEntity.Description,
                ExpenseType = tripEntity.ExpenseType,
            };
        }
    }
}

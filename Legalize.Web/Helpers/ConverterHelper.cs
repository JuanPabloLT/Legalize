using Legalize.Common.Models;
using Legalize.Web.Data.Entities;
using System.Linq;


namespace Legalize.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public LegalizeResponse ToLegalizeResponse(LegalizeEntity legalize)
        {
            return new LegalizeResponse
            {
                Id = legalize.Id,
                EmployeeId = legalize.EmployeeId,
            };
        }

        public LegalizeResponse ToTripResponse(LegalizeEntity legalizeEntity)
        {
            return new LegalizeResponse
            {
                Id = legalizeEntity.Id,
                EmployeeId = legalizeEntity.EmployeeId,
                Trips = legalizeEntity.Trips?.Select(tr => new TripResponse
                {
                    Id = tr.Id,
                    StartDate = tr.StartDate,
                    EndDate = tr.EndDate,
                    TotalAmount = tr.TotalAmount,
                    City = tr.City.Name,
                    TripDetails = tr.TripDetails.Select(tdr => new TripDetailResponse
                    {
                        Id = tdr.Id,
                        Date = tdr.Date,
                        Amount = tdr.Amount,
                        Description = tdr.Description,
                        PicturePath = tdr.PicturePath,

                    }).ToList(),
                }).ToList(),
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



        /* public TripResponse ToTripResponse(TripEntity tripEntity)
         {
             return new TripResponse
             {
                 EndDate = tripEntity.EndDate,
                 Id = tripEntity.Id,
                 Qualification = tripEntity.Qualification,
                 Remarks = tripEntity.Remarks,
                 Source = tripEntity.Source,
                 SourceLatitude = tripEntity.SourceLatitude,
                 SourceLongitude = tripEntity.SourceLongitude,
                 StartDate = tripEntity.StartDate,
                 Target = tripEntity.Target,
                 TargetLatitude = tripEntity.TargetLatitude,
                 TargetLongitude = tripEntity.TargetLongitude,
                 TripDetails = tripEntity.TripDetails?.Select(td => new TripDetailResponse
                 {
                     Date = td.Date,
                     Id = td.Id,
                     Latitude = td.Latitude,
                     Longitude = td.Longitude
                 }).ToList(),
                 User = ToUserResponse(tripEntity.User)
             };
         }

         public LegalizeResponse ToTaxiResponse(LegalizeEntity legalizeEntity)
         {
             return new LegalizeResponse
             {
                 Id = legalizeEntity.Id,
                 EmployeeId = legalizeEntity.EmployeeId,
                 Trips = legalizeEntity.Trips?.Select(t => new TripResponse
                 {
                     EndDate = t.EndDate,
                     Id = t.Id,
                     Qualification = t.Qualification,
                     Remarks = t.Remarks,
                     Source = t.Source,
                     SourceLatitude = t.SourceLatitude,
                     SourceLongitude = t.SourceLongitude,
                     StartDate = t.StartDate,
                     Target = t.Target,
                     TargetLatitude = t.TargetLatitude,
                     TargetLongitude = t.TargetLongitude,
                     TripDetails = t.TripDetails?.Select(td => new TripDetailResponse
                     {
                         Date = td.Date,
                         Id = td.Id,
                         Latitude = td.Latitude,
                         Longitude = td.Longitude
                     }).ToList(),
                     User = ToUserResponse(t.User)
                 }).ToList(),
                 User = ToUserResponse(taxiEntity.User)
             };
         }*/










    }
    }

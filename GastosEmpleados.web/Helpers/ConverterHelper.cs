using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GastosEmpleado.Common.Models;
using GastosEmpleados.web.Data.Entities;

namespace GastosEmpleados.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public TripResponse ToTripResponse(TripsEntity tripsEntity)
        {
            return new TripResponse
            {
                EndDate = tripsEntity.EndDate,
                Id = tripsEntity.Id,
                Remarks = tripsEntity.Remarks,
                Source = tripsEntity.Source,
                StartDate = tripsEntity.StartDate,
                Target = tripsEntity.Target,
                TripDetails = tripsEntity.TripDetails?.Select(td => new TripDetailResponse
                {
                    Date = td.Date,
                    Id = td.Id,
                }).ToList(),
                User = ToUserResponse(tripsEntity.User)
            };
        }


        public EmployeesResponse ToEmployeesResponse(EmployeesEntity employeesEntity)
        {
            return new EmployeesResponse
            {
                Id = employeesEntity.Id,
                Document = employeesEntity.Document,
                Trips = employeesEntity.Trips?.Select(t => new TripResponse
                {
                    EndDate = t.EndDate,
                    Id = t.Id,
                    Source = t.Source,
                    StartDate = t.StartDate,
                    Target = t.Target,
                    TripDetails = t.TripDetails?.Select(td => new TripDetailResponse
                    {
                        Date = td.Date,
                        Id = td.Id,
                    }).ToList(),
                    User = ToUserResponse(t.User)
                }).ToList(),
                User = ToUserResponse(employeesEntity.User)
            };
        }

        private UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                UserType = user.UserType
            };
        }
    }
}


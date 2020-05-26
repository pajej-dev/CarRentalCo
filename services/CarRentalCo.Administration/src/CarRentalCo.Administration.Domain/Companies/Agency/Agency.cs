using CarRentalCo.Administration.Domain.Companies.Exceptions;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalCo.Administration.Domain.Companies
{
    public class Agency : IEntity<AgencyId>
    {
        public AgencyId Id { get; private set; }
        public AgencyRole Role { get; private set; }
        public AgencyAdress Adress { get; private set; }
        public DateTime RoleAssignDate { get; private set; }
        public DateTime SetUpDate { get; private set; }
        public IList<RentalCarId> RentalCars { get; private set; }

        //todo employers

        private Agency()
        {
        }

        private Agency(AgencyId companyLocationId, AgencyRole companyLocationRole, DateTime roleAssignDate, DateTime setUpDate)
        {
            Id = companyLocationId;
            Role = companyLocationRole;
            RoleAssignDate = roleAssignDate;
            SetUpDate = SetUpDate;
            RentalCars = new List<RentalCarId>();
        }

        public static Agency Create(AgencyId companyLocationId, AgencyRole companyLocationRole, IDateTimeProvider provider)
        {
            //todo val
            var currentDate = provider.UtcNow;
            return new Agency(companyLocationId, companyLocationRole, currentDate, currentDate);
        }

        public void ChangeRoleToStandard(IDateTimeProvider provider)
        {
            if (RoleAssignDate.Month == provider.UtcNow.Month)
                throw new AgencyRoleChangeRejectedException($"Agency Headquarter can be change to standard only once per month." +
                    $" Last change: {RoleAssignDate.ToShortDateString()}");

            Role = AgencyRole.Standard;
            RoleAssignDate = provider.UtcNow;
        }

        public void ChangeRoleToHeadquarter(IDateTimeProvider provider)
        {
            Role = AgencyRole.Headquarter;
            RoleAssignDate = provider.UtcNow;
        }

        public void AddRentalCar(RentalCarId rentalCarId)
        {
            if (RentalCars.Any(x => x.Id == rentalCarId.Id))
                throw new RentalCarAlreadyAddedException($"Cannot add rentalCarId: {rentalCarId} because It exists in agency");

            if (RentalCars.Count > 30)
                throw new RentalCarsInAgencyExceededException($"Agency cannot contains more than 30 cars");

            RentalCars.Add(rentalCarId);
        }
    }
}
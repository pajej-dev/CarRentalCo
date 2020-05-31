using CarRentalCo.Administration.Domain.Companies.Exceptions;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Domain;
using CarRentalCo.Common.Other;
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

        public  Agency(AgencyId agencyId, AgencyAdress adress, AgencyRole agencyRole, DateTime roleAssignDate, DateTime setUpDate, IList<RentalCarId> rentalCars = null)
        {
            Id = agencyId;
            Adress = adress;
            Role = agencyRole;
            RoleAssignDate = roleAssignDate;
            SetUpDate = SetUpDate;
            RentalCars = rentalCars ?? new List<RentalCarId>();
        }

        public static Agency Create(AgencyId agencyId, AgencyAdress adress, AgencyRole agencyRole)
        {
            //todo val
            var currentDate = SystemTime.UtcNow;
            return new Agency(agencyId, adress, agencyRole, currentDate, currentDate);
        }

        public void ChangeRoleToStandard()
        {
            if (RoleAssignDate.Month == SystemTime.UtcNow.Month)
                throw new AgencyRoleChangeRejectedException($"Agency Headquarter can be change to standard only once per month." +
                    $" Last change: {RoleAssignDate.ToShortDateString()}");

            Role = AgencyRole.Standard;
            RoleAssignDate = SystemTime.UtcNow;
        }

        public void ChangeRoleToHeadquarter()
        {
            Role = AgencyRole.Headquarter;
            RoleAssignDate = SystemTime.UtcNow;
        }

        public void AddRentalCar(RentalCarId rentalCarId)
        {
            if (RentalCars.Any(x => x.Value == rentalCarId.Value))
                throw new RentalCarAlreadyAddedException($"Cannot add rentalCarId: {rentalCarId} because It already exists in agency");

            if (RentalCars.Count > 30)
                throw new RentalCarsInAgencyExceededException($"Agency cannot contains more than 30 cars");

            RentalCars.Add(rentalCarId);
        }
    }
}
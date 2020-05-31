using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Administration.Domain.RentalCars
{
    public class RentalCarOperatingInfo : ValueObject<RentalCarOperatingInfo>
    {
        public DateTime TechnicalReviewValidThru { get; private set; }
        public DateTime InsurrenceValidThru { get; private set; }
        public DateTime OilValidThru { get; private set; }

        public  RentalCarOperatingInfo(DateTime technicalReviewValidThru, DateTime insurrenceValidThru, DateTime oilValidThru)
        {
            //perform date validation (date must be greater than today)

            TechnicalReviewValidThru = technicalReviewValidThru;
            InsurrenceValidThru = insurrenceValidThru;
            OilValidThru = oilValidThru;
        }


        public static RentalCarOperatingInfo Create(DateTime technicalReviewValidThru, DateTime insurrenceValidThru, DateTime oilValidThru)
        {
            return new RentalCarOperatingInfo(technicalReviewValidThru, insurrenceValidThru, oilValidThru);
        }

        protected override bool Equals(ValueObject<RentalCarOperatingInfo> other)
        {
            var otherCarOperatingInfo = other as RentalCarOperatingInfo;

            if (TechnicalReviewValidThru != otherCarOperatingInfo.TechnicalReviewValidThru)
                return false;

            if (InsurrenceValidThru != otherCarOperatingInfo.InsurrenceValidThru)
                return false;

            if (OilValidThru != otherCarOperatingInfo.OilValidThru)
                return false;

            return true;
        }
    }
}
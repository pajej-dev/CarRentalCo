using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Administration.Domain.RentalCars
{
    public class RentalCarSpecification : ValueObject<RentalCarSpecification>
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public Colour Colour { get; private set; }

        private RentalCarSpecification() { }

        private RentalCarSpecification(string brand, string model, DateTime productionDate, Colour colour)
        {
            this.Brand = brand;
            this.Model = model;
            this.ProductionDate = productionDate;
            this.Colour = colour;
        }

        public static RentalCarSpecification Create(string brand, string model, DateTime productionDate, Colour colour)
        {
            //todo perform validations

            return new RentalCarSpecification(brand, model, productionDate, colour);
        }

        protected override bool Equals(ValueObject<RentalCarSpecification> other)
        {
            var otherSpecification = other as RentalCarSpecification;

            if (Brand != otherSpecification.Brand)
                return false;

            if (Model != otherSpecification.Model)
                return false;

            if (ProductionDate != otherSpecification.ProductionDate)
                return false;

            if (Colour != otherSpecification.Colour)
                return false;

            return true;
        }
    }

    public enum Colour
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black,
        Purple
    }
}
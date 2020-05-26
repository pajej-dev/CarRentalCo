using CarRentalCo.Administration.Domain.Companies.Exceptions;
using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies
{
    public class AgencyAdress : ValueObject<AgencyAdress>
    {
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }


        private AgencyAdress()
        {
        }
        private AgencyAdress(string street, int number, string city, string postalCode, string country)
        {
            this.Street = street;
            this.Number = number;
            this.City = city;
            this.PostalCode = postalCode;
            this.Country = country;
        }

        public static AgencyAdress Create(string street, int number, string city, string postalCode, string country)
        {
            //todo extract validators and validate postal code 
            if (string.IsNullOrWhiteSpace(street))
                throw new InvalidAgencyAdressParameterException(nameof(street));

            if (number == default)
                throw new InvalidAgencyAdressParameterException(nameof(number));

            if (string.IsNullOrWhiteSpace(city))
                throw new InvalidAgencyAdressParameterException(nameof(city));

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new InvalidAgencyAdressParameterException(nameof(postalCode));

            if (string.IsNullOrWhiteSpace(country))
                throw new InvalidAgencyAdressParameterException(nameof(country));

            return new AgencyAdress(street, number, city, postalCode, country);
        }

        protected override bool Equals(ValueObject<AgencyAdress> other)
        {
            var otherStreet = other as AgencyAdress;

            if (this.Street != otherStreet.Street)
                return false;

            if (this.Number != otherStreet.Number)
                return false;

            if (this.PostalCode != otherStreet.PostalCode)
                return false;

            if (this.City != otherStreet.City)
                return false;

            if (this.Country != otherStreet.Country)
                return false;


            return true;
        }
    }
}
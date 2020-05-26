using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies
{
    public class CompanyContact : ValueObject<CompanyContact>
    {
        public string Email { get; private set; }
        public string Phone { get; private set; }

        private CompanyContact()
        {
        }

        private CompanyContact(string email, string phone)
        {
            this.Email = email;
            this.Phone = phone;
        }
        
        public CompanyContact Create(string email, string phone)
        {
            //validate email and phone

            return new CompanyContact(email, phone);
        }
        protected override bool Equals(ValueObject<CompanyContact> other)
        {
            var otherCompanyContact = other as CompanyContact;

            if (Email != otherCompanyContact.Email)
                return false;

            if (Phone != otherCompanyContact.Phone)
                return false;

            return true;
        }
    }
}
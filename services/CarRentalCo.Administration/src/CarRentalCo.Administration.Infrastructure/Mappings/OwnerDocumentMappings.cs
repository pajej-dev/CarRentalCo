using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Administration.Infrastructure.Mongo.Owners;

namespace CarRentalCo.Administration.Infrastructure.Mappings
{
    public static class OwnerDocumentMappings
    {
        public static Owner ToAggregate(this OwnerDocument doc)
            => new Owner(new OwnerId(doc.Id), doc.FullName, doc.Email, doc.DateOfBirth, doc.CreationDate);

        public static OwnerDocument ToDocument(this Owner owner)
            => new OwnerDocument
            {
                Id = owner.Id.Value,
                DateOfBirth = owner.DateOfBirth,
                CreationDate = owner.CreationDate,
                Email = owner.Email,
                FullName = owner.FullName,
                ModificationDate = owner.ModificationDate
            };

    }
}

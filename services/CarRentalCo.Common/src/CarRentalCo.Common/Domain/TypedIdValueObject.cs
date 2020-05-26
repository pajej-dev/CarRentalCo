using System;

namespace CarRentalCo.Common.Domain
{
    public abstract class TypedIdValueObject : ValueObject<TypedIdValueObject>
    {
        public Guid Id { get; }

        public TypedIdValueObject(Guid value)
        {
            if (value == Guid.Empty)
                throw new InvalidOperationException("Identifier cannot be empty!");
            Id = value;
        }

        protected override bool Equals(ValueObject<TypedIdValueObject> other)
        {
            return other is TypedIdValueObject && this.Id == (other as TypedIdValueObject).Id;
        }
    }
}
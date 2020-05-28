using System;

namespace CarRentalCo.Common.Domain
{
    public abstract class TypedIdValueObject : ValueObject<TypedIdValueObject>
    {
        public Guid Value { get; }

        public TypedIdValueObject(Guid value)
        {
            if (value == Guid.Empty)
                throw new InvalidOperationException("Identifier cannot be empty!");
            Value = value;
        }

        protected override bool Equals(ValueObject<TypedIdValueObject> other)
        {
            return other is TypedIdValueObject && this.Value == (other as TypedIdValueObject).Value;
        }
    }
}
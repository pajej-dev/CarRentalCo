namespace CarRentalCo.Common.Domain
{
    public interface IEntity<T> where T : TypedIdValueObject
    {
        public T Id { get; }
    }
}

namespace FormApi.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

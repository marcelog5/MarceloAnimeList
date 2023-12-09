namespace CarRare.Common.DomainLayer.Data
{
    public interface IDomainEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        bool Active { get; set; }
    }
}

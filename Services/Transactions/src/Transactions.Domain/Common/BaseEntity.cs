namespace Transactions.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

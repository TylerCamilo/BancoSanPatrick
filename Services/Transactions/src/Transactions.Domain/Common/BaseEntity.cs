namespace Transactions.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifyBy { get; set; }
        public DateTime? LastModifyAt { get; set; }
    }
}

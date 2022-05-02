using Transactions.Domain.Common;

namespace Transactions.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Balance { get; set; }

        public string OriginCard { get; set; } = string.Empty;

        public string DestinationCard { get; set; }

        public decimal Amount { get; set; }

        public string ReferenceNumber { get; set; }

      

    }
}

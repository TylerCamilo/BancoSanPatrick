using Transactions.Domain.Common;

namespace Transactions.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(string originCardId, decimal balance, string destinationCardId, decimal amount, int referenceNumber)
        {
            OriginCardId = originCardId;
            Balance = balance;
            DestinationCardId = destinationCardId;
            Amount = amount;
            MadeAt = DateTime.Now;
            ReferenceNumber = referenceNumber;
        }

        public string OriginCardId { get; set; }

        public decimal Balance { get; set; }

        public string DestinationCardId { get; set; }

        public decimal Amount { get; set; }

        public DateTime MadeAt { get; set; }

        public int ReferenceNumber { get; set; }

    }
}

using Transactions.Domain.Common;

namespace Transactions.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(decimal balance, string originCard,  string destinationCard, decimal amount, string referenceNumber = null)
        {
            Balance = balance;
            OriginCard = originCard;
            DestinationCard = destinationCard;
            Amount = amount;
            ReferenceNumber = (referenceNumber != null) ? referenceNumber : CreateReferenceNumber();
            MadeAt = DateTime.Now;
            
        }

        public decimal Balance { get; set; }

        public string OriginCard { get; set; }

        public string DestinationCard { get; set; }

        public decimal Amount { get; set; }

        public string ReferenceNumber { get; set; }

        public DateTime MadeAt { get; private set; }

        private string CreateReferenceNumber()
        {
            Random random = new Random();
            var nReference = random.Next(100000, 999999);
            return nReference.ToString();
        }

    }
}

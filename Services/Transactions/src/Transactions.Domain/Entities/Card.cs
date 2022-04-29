using Transactions.Domain.Common;

namespace Transactions.Domain.Entities
{
    public class Card : BaseEntity
    {
        public Card(string alias, string userId)
        {
            Number = GenerateCardNumber();
            Alias = alias ;
            ExpiryDate = DateTime.Now.AddYears(6);
            SecurityCode = GenerateSecurityCode();
            UserId = userId;
        }

        
        public string Number { get; private set; }

        public string? Alias { get; set; }

        public DateTime ExpiryDate { get; private set; }

        public string SecurityCode { get; private set; }
     
        public string UserId { get; set; }

        //public BankUser User { get; set; }

        private string GenerateCardNumber()
        {
            Random random = new Random();
            var card = random.Next(100, 999);
            return card.ToString();
        }

        private string GenerateSecurityCode()
        {
            Random random = new Random();
            long card = random.NextInt64(1000000000000000, 9999999999999999);
            return card.ToString();
        }

    }
}

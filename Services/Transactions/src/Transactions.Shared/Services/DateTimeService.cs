using Transactions.Application.Interfaces;

namespace Transactions.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUTC => DateTime.Now;

    }
}

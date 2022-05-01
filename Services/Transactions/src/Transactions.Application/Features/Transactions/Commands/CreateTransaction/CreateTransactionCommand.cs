using MediatR;
using Transactions.Application.Wrappers;

namespace Transactions.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<Response<string>>
    {
        public decimal Balance { get; set; }

        public string OriginCard { get; set; }

        public string DestinationCard { get; set; }

        public decimal Amount { get; set; }

        public string? ReferenceNumber { get; set; }
    }
}

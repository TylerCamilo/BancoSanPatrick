using MediatR;
using Transactions.Application.Wrappers;

namespace Transactions.Application.Features.Transactions.Commands.CreateTransactionsCommand
{
    public class CreateTransactionCommand : IRequest<Response<string>>
    {
        public string? Alias { get; set; }

        public string UserId { get; set; }
    }
}

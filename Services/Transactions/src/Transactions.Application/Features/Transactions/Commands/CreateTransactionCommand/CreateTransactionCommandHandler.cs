using MediatR;
using Transactions.Application.Features.Transactions.Commands.CreateTransactionsCommand;
using Transactions.Application.Wrappers;

namespace Transactions.Application.Features.Transactions.Commands.CreateCardCommand
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<string>>
    {
        public Task<Response<string>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

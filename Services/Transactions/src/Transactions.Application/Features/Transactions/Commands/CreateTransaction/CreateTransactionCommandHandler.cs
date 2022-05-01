using MediatR;
using Transactions.Application.Wrappers;

namespace Transactions.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<string>>
    {
        public Task<Response<string>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

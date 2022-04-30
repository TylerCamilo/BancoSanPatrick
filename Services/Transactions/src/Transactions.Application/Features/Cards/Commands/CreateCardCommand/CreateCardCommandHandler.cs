using MediatR;
using Transactions.Application.Wrappers;

namespace Transactions.Application.Features.Cards.Commands.CreateCardCommand
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Response<string>>
    {
        public Task<Response<string>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

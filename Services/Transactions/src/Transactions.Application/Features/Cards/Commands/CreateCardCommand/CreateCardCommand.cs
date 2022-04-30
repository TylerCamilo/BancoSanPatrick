using MediatR;
using Transactions.Application.Wrappers;

namespace Transactions.Application.Features.Cards.Commands.CreateCardCommand
{
    public class CreateCardCommand : IRequest<Response<string>>
    {
        public string? Alias { get; set; }

        public string UserId { get; set; }
    }
}

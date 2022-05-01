using AutoMapper;
using MediatR;
using Transactions.Application.Interfaces;
using Transactions.Application.Wrappers;
using Transactions.Domain.Entities;

namespace Transactions.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Transaction> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(IRepositoryAsync<Transaction> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Transaction>(request);
            var data = await _repositoryAsync.AddAsync(record);

            return new Response<string>(data.Id);


        }
    }
}

using AutoMapper;
using Transactions.Application.Features.Transactions.Commands.CreateTransaction;
using Transactions.Domain.Entities;

namespace Transactions.Application.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            #region Commands
            CreateMap<CreateTransactionCommand, Transaction>();
            #endregion
        }
    }
}

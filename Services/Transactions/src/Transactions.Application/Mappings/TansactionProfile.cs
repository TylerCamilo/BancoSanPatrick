using AutoMapper;
using Transactions.Application.Features.Transactions.Commands.CreateTransaction;
using Transactions.Domain.Entities;

namespace Transactions.Application.Mappings
{
    public class TansactionProfile : Profile
    {
        public TansactionProfile()
        {
            #region Commands
            CreateMap<CreateTransactionCommand, Transaction>();
            #endregion
        }
    }
}

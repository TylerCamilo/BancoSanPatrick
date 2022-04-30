using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Application.Interfaces
{
    internal interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class 
    {
    }
}

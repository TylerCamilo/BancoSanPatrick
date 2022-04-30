using Ardalis.Specification.EntityFrameworkCore;
using Transactions.Application.Interfaces;
using Transactions.Persistence.Contexts;

namespace Transactions.Persistence.Repositories
{
    public class RespositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly AppDbContext _context;

        public RespositoryAsync(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

using Abp.EntityFrameworkCore;
using SmartPoultry.Models;

namespace SmartPoultry.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : SmartPoultryRepositoryBase<Customer>
    {
        public CustomerRepository(IDbContextProvider<SmartPoultryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

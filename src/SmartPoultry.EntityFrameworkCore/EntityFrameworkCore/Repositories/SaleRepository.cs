using Abp.EntityFrameworkCore;
using SmartPoultry.Models;

namespace SmartPoultry.EntityFrameworkCore.Repositories
{
    public class SaleRepository :  SmartPoultryRepositoryBase<Sale>
    {
        public SaleRepository(IDbContextProvider<SmartPoultryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}

using Abp.EntityFrameworkCore;
using SmartPoultry.Models;

namespace SmartPoultry.EntityFrameworkCore.Repositories
{
    public class SupplierRepository : SmartPoultryRepositoryBase<Supplier>
    {
        public SupplierRepository(IDbContextProvider<SmartPoultryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }

}

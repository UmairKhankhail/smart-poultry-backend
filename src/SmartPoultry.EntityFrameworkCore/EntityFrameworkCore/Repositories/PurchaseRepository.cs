using Abp.EntityFrameworkCore;
using SmartPoultry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.EntityFrameworkCore.Repositories
{
    public class PurchaseRepository : SmartPoultryRepositoryBase<Purchase>
    {
        public PurchaseRepository(IDbContextProvider<SmartPoultryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}

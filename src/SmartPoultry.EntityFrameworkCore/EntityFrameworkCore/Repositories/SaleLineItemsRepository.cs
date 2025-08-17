using Abp.EntityFrameworkCore;
using SmartPoultry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.EntityFrameworkCore.Repositories
{
    public class SaleLineItemsRepository : SmartPoultryRepositoryBase<SaleLineItem>
    {
        public SaleLineItemsRepository(IDbContextProvider<SmartPoultryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}

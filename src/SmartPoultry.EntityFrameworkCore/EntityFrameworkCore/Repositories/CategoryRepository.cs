using Abp.EntityFrameworkCore;
using SmartPoultry.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : SmartPoultryRepositoryBase<Category>
    {
        public CategoryRepository(IDbContextProvider<SmartPoultryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}

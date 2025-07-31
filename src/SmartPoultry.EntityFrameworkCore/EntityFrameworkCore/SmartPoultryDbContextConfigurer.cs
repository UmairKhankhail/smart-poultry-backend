using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SmartPoultry.EntityFrameworkCore
{
    public static class SmartPoultryDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SmartPoultryDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SmartPoultryDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

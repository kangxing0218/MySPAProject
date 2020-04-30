using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MySpaProject.Authorization.Roles;
using MySpaProject.Authorization.Users;
using MySpaProject.MultiTenancy;
using MySpaProject.PhoneBook.PhoneBooks.Persons;
using MySpaProject.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MySpaProject.EntityFrameworkCore
{
    public class MySpaProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MySpaProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Person> Persons { get; set; }


        public DbSet<PhoneNumber> PhoneNumbers { get; set; }


        public MySpaProjectDbContext(DbContextOptions<MySpaProjectDbContext> options)
            : base(options)
        {
        }
    }
}

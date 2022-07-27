using ACG_Master.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACG_Master.DataBase
{
    public class ACGContext : DbContext
    {

        public ACGContext(DbContextOptions options) : base(options) {}

        DbSet<User> Users { get; set; }
    }
}

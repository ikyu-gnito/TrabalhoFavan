using Cartorio_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Cartorio_CRUD.Data
{
    public class ApplicatonDbContext : DbContext
    {
        public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext> options) : base(options)
        {
        }

        public DbSet<RegistroModel> Registros { get; set; }

    }
}

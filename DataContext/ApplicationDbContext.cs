using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Modals;

namespace PrimeiraApi.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }

    }
}

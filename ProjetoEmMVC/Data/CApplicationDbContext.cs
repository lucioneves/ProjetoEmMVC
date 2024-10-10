using Microsoft.EntityFrameworkCore;
using ProjetoEmMVC.Models;

namespace ProjetoEmMVC.Data
{
    public class CApplicationDbContext : DbContext
    {
        public CApplicationDbContext(DbContextOptions<CApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmprestimosModel> Emprestimos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

using InfoWinDev.UI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InfoWinDev.UI.Data
{
    public class InfoWinDevDataContext:DbContext
    {
        private readonly IConfiguration _config;

        public InfoWinDevDataContext(IConfiguration config)
        {
            _config = config;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("InfoWinDevConn"));
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}

using InfoWinDev.UI.Models;
using System.Collections.Generic;
using System.Linq;
using InfoWinDev.UI.Infra;

namespace InfoWinDev.UI.Data
{
    public class DbInitializer
    {
        public static void Init(InfoWinDevDataContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (!ctx.Produtos.Any())
            {

                var alimentacao = new TipoProduto() { Nome = "Alimentação" };
                var higiene = new TipoProduto() { Nome = "Higiene" };
                var vestuario = new TipoProduto() { Nome = "Vestuário" };

                var produtos = new List<Produto>() {
                    new Produto(){Nome = "Picanha", Tipo = alimentacao, Valor= 80.99M },
                    new Produto(){Nome = "Fralda", Tipo = higiene, Valor= 50.99M },
                    new Produto(){Nome = "Pasta de Dente", Tipo = higiene, Valor= 10.50M },
                    new Produto(){Nome = "Iogurte", Tipo = alimentacao, Valor= 9.99M },
                    new Produto(){Nome = "Camisa Polo", Tipo = vestuario, Valor= 100.99M },
                };

                ctx.Produtos.AddRange(produtos);
                ctx.SaveChanges();



            }

            if (!ctx.Usuarios.Any())
            {
                ctx.Usuarios.AddRange(new List<Usuario>
                {
                    new Usuario{ Nome = "Gabriel Rodrigues", Email = "gabriel.d.o.rodrigues@gmail.com", Senha = "123456".Encrypt()},
                    new Usuario{Nome = "Maria Graça", Email = "maria.graca@gmail.com", Senha = "789012".Encrypt()}
                });
                ctx.SaveChanges();
            }



        }
    }
}

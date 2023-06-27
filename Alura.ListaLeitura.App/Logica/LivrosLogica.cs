using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogca
    {
        public static Task LivrosParaLer(HttpContext context)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("para-ler");
            var _repo = new LivroRepositorioCSV();
            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro}</li> #NOVO-ITEM#");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", " ");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task LivrosLendo(HttpContext context)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lendo");
            var _repo = new LivroRepositorioCSV();
            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro}</li> #NOVO-ITEM#");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", " ");

            return context.Response.WriteAsync(conteudoArquivo);
        }
        public static Task LivrosLidos(HttpContext context)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lidos");
            var _repo = new LivroRepositorioCSV();
            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro}</li> #NOVO-ITEM#");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", " ");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();

            var livro = repo.Todos.First(x => x.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }
    }
}

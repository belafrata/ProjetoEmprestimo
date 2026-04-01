using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoEmprestimo.GerenciaArquivos;
using ProjetoEmprestimo.Models;
using ProjetoEmprestimo.Repository.Contract;

namespace ProjetoEmprestimo.Controllers
{
    public class LivrosController : Controller
    {
        private ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro realizado";
            return View();
        }


        //public IActionResult CadLivro()
        //{
        //    var listCategorias = _categoriaRepository.ObterTodosCategorias();
        //    ViewBag.Categorias = new SelectList(listCategorias, "codCategoria", "descricao");
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CadLivro(Livro livro, IFormFile file)
        //{
        //    var listCategorias = _categoriaRepository.ObterTodosCategorias();
        //    ViewBag.Categorias = new SelectList(listCategorias, "codCategoria", "descricao");

        //    var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

        //    livro.imagemLivro = Caminho;

        //    _livroRepository.Cadastrar(livro);

        //    ViewBag.msg = "Cadastro realizado";
        //    return View();
        //}
    }
}


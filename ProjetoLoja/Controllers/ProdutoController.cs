using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;

namespace ProjetoLoja.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }


        public IActionResult Index()
        {
            var produtos = _produtoRepositorio.ListarTudo();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProduto(ProdutoViewModel prodmodel)
        {
            if (!ModelState.IsValid) return View(prodmodel);

            var produto = new ProdutoViewModel
            {
                Nome = prodmodel.Nome,
                Preco = prodmodel.Preco,
            };

            _produtoRepositorio.CadastrarProdutudo(produto);
            return RedirectToAction(nameof(Index));
        }
    }
}

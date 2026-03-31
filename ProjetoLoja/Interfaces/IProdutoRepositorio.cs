using ProjetoLoja.Models;

namespace ProjetoLoja.Interfaces
{
    public interface IProdutoRepositorio
    {
        IEnumerable<ProdutoViewModel> ListarTudo();

        ProdutoViewModel? ObterId(int id);

        void CadastrarProdutudo(ProdutoViewModel produto);
    }
}

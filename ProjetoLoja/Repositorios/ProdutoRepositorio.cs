using MySql.Data.MySqlClient;
using ProjetoLoja.Models;

namespace ProjetoLoja.Repositorios
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString;

        public ProdutoRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao");
        }

        public IEnumerable<ProdutoViewModel> ListarTudo()
        {
            var lista = new List<ProdutoViewModel>();

            using var conn = new MySqlConnection(_connectionString);

            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM Produtos", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new ProdutoViewModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString()!,
                    Preco = Convert.ToDecimal(reader["Preco"]),
                });
            }
            return lista;

        }

        public ProdutoViewModel? ObterId(int id)
        {
            using var conn = new MySqlConnection(_connectionString);

            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM Produtos WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new ProdutoViewModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString()!,
                    Preco = Convert.ToDecimal(reader["Preco"]),
                };
            }
            return null;
        }

        public void CadastrarProduto(ProdutoViewModel prodmodel)
        {
            using var conn = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand("INSERT INTO Produtos (Nome,Preco) VALUES(@nome, @preco)", conn);
            cmd.Parameters.AddWithValue("@nome",prodmodel.Nome);
            cmd.Parameters.AddWithValue("@preco", prodmodel.Preco);
            cmd.ExecuteNonQuery();
        }
    }
}

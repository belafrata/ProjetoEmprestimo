using MySql.Data.MySqlClient;
using ProjetoEmprestimo.Repository.Contract;

namespace ProjetoEmprestimo.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly string _conexaoMySQL;

        public EmprestimoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(EmprestimoRepository emprestimo)
        {
            throw new NotImplementedException();
        }

        public void buscaIdEmp(EmprestimoRepository emprestimo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EmprestimoRepository emprestimo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbEmprestimo values(default, @dtEmpre, @dtDev, @codUsu)", conexao);

                cmd.Parameters.Add("@dtEmpre", MySqlDbType.VarChar).Value = emprestimo.dtEmpre;
                cmd.Parameters.Add("@dtEmpre", MySqlDbType.VarChar).Value = emprestimo.dtEmpre;
                cmd.Parameters.Add("@dtEmpre", MySqlDbType.VarChar).Value = emprestimo.dtEmpre;
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public EmprestimoRepository ObterEmprestimos(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmprestimoRepository> ObterTodosEmprestimo()
        {
            throw new NotImplementedException();
        }
    }
}

using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface IEmprestimoRepository
    {
        IEnumerable<EmprestimoRepository> ObterTodosEmprestimo();
        void Cadastrar (EmprestimoRepository emprestimo);
        void Atualizar (EmprestimoRepository emprestimo);
        EmprestimoRepository ObterEmprestimos(int Id);
        void buscaIdEmp (EmprestimoRepository emprestimo);
        void Excluir(int Id);
    }
}

using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Repository.Contract
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Emprestimo> ObterTodosEmprestimo();
        void Cadastrar (Emprestimo emprestimo);
        void Atualizar (Emprestimo emprestimo);
        Emprestimo ObterEmprestimos(int Id);
        void buscaIdEmp (Emprestimo emprestimo);
        void Excluir(int Id);
    }
}

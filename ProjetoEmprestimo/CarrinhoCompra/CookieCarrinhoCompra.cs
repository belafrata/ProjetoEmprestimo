using Newtonsoft.Json;

namespace ProjetoEmprestimo.CarrinhoCompra
{
    public class CookieCarrinhoCompra
    {
        //criar chave
        private string Key = "Carrinho.Compras";
        private Cookie.Cookie _cookie;

        public CookieCarrinhoCompra(Cookie.Cookie cookie)
        {
            _cookie = cookie;
        }

        //Salvar
        public void Salvar(List<Livro> Lista)
        {
            string Valor = JsonConvert.SerializeObject(Lista);
            _cookie.Cadastrar(Key, Valor);
        }

        //Consulta
    }
}

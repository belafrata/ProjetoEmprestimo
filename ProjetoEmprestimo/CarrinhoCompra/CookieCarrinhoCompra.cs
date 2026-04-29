using Newtonsoft.Json;
using ProjetoEmprestimo.Models;

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
        public List<Livro> Consultar()
        {
            if (_cookie.Existe(Key))
            {
                string valor = _cookie.Consultar(Key);
                return JsonConvert.DeserializeObject<List<Livro>>(valor);
            }
            else
            {
                return new List<Livro>();
            }
        }

        //Cadastrar
        public void Cadastrar(Livro item)
        {
            List<Livro> Lista;
            if (_cookie.Existe(Key))
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.codLivro == item.codLivro);

                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
                else
                {
                    ItemLocalizado.quantidade = ItemLocalizado.quantidade + 1;
                }
            }
            else
            {
                Lista = new List<Livro>();
                Lista.Add(item);
            }
            Salvar(Lista);
        }
        //Atualiza
        public void Atualizar(Livro item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.codLivro == item.codLivro);

            if (ItemLocalizado != null)
            {
                ItemLocalizado.quantidade = item.quantidade + 1;
                Salvar(Lista);
            }
        }
        public void Remover(Livro item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.codLivro == item.codLivro);

            if (ItemLocalizado != null)
            {
                Lista.Remove(ItemLocalizado);
                Salvar(Lista);
            }
        }
        //verifica se existe
        public bool Existe(string Key)
        {
            if (_cookie.Existe(Key))
            { 
                return false;
            }

            return true;
        }
        //remove todos os itens do carrinho
        public void RemoverTodos()
        {
            _cookie.Remover(Key);
        }
    }
}

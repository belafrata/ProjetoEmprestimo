

namespace ProjetoEmprestimo.Cookie
{
    public class Cookie
    {
        private IHttpContextAccessor _context;
        private IConfiguration _configuration;

        public Cookie(IHttpContextAccessor context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Cadastrar(string Key, string Value)
        {
            CookieOptions Options = new CookieOptions();
            Options.Expires = DateTime.Now.AddDays(7);
            Options.IsEssential = true;

            _context.HttpContext.Response.Cookies.Append(Key, Value, Options);
        }
        public void Remover(string Key)
        {
            _context.HttpContext.Response.Cookies.Delete(Key);
        }
        public string Consultar(string Key, bool Cript = true)
        {
            var valor = _context.HttpContext.Request.Cookies[Key];
            return valor;
        }
        public bool Existe(string Key)
        {
            if (_context.HttpContext.Request.Cookies[Key] == null)
            {
                return false;
            }

            return true;
        }
        public void Atualizar(string Key, string Value)
        {
            if (Existe(Key))
            {
                Remover(Key);
            }
            Cadastrar(Key, Value);
        }
    }
}

using pet_show_front.Models.MainModels;

namespace pet_show_front.Business.AppBusiness
{
    public class UsuariosAppBusiness
    {
        public Usuario GetUsuario()
        {
            return App.ConexaoSqlite.Table<Usuario>().FirstOrDefault();
        }
        
        public void Inserir(Usuario usuario)
        {
            var usuarioLogado = GetUsuario(usuario.Id);

            if(usuarioLogado != null)
            {
                App.ConexaoSqlite.Update(usuario);
            }
            else
            {
                App.ConexaoSqlite.Insert(usuario);
            }           
        }
        
        public int Excluir(int id)
        {
            return App.ConexaoSqlite.Delete<Usuario>(id);
        }

        public Usuario GetUsuario(int id)
        {
            return App.ConexaoSqlite.Table<Usuario>().FirstOrDefault(x=> x.Id == id);
        }

    }
}

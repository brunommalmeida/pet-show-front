using pet_show_front.Business.ApiBusiness;
using pet_show_front.Business.AppBusiness;
using pet_show_front.Models.MainModels;
using pet_show_front.Views.MainViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Main
{
    public class LoginViewModel : BaseViewModel
    {

        public ICommand LoginCommand { get; private set; }

        string loginUsuario = string.Empty;
        string senha = string.Empty;

        public string LoginUsuario
        {
            get { return loginUsuario; }
            set
            {
                loginUsuario = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
        }

        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(LoginUsuario))
            {
                App.Current.MainPage.DisplayAlert("Informação", "O campo usuário é obrigatório.", "Ok");
                return false;
            }
                
            if (string.IsNullOrEmpty(Senha))
            {
                App.Current.MainPage.DisplayAlert("Informação", "O campo senha é obrigatório.", "Ok");
                return false;
            }                

            return true;

        }

        private void SalvaUsuarioLocal(Usuario usuario)
        {
            try
            {
                UsuariosAppBusiness usuariosAppBusiness = new UsuariosAppBusiness();
                usuariosAppBusiness.Inserir(usuario);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void Login()
        {
            try
            {

                if (!ValidaCampos())
                {                   
                    return;
                }

                IsBusy = true;

                Usuario usuario = new Usuario();
                usuario.UsuarioLogin = LoginUsuario;
                usuario.Senha = Senha;

                UsuariosApiBusiness usuariosApiBusiness = new UsuariosApiBusiness();

                var usuarioLogin = await usuariosApiBusiness.LoginApp(usuario);

                if (usuarioLogin != null)
                {
                    SalvaUsuarioLocal(usuarioLogin);
                    App.Usuario = usuarioLogin;

                    App.Current.MainPage = new NavigationPage(new pgHomePage(false, true));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Informação", "Usuário ou senha inválidos.", "Ok");
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Erro: " + ex.Message, "Ok");
            }

            IsBusy = false;
        }
    }
}

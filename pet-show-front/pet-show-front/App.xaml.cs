using pet_show_front.Business.AppBusiness;
using pet_show_front.Interfaces;
using pet_show_front.Models.MainModels;
using pet_show_front.Views.MainViews;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Label = Xamarin.Forms.Label;
namespace pet_show_front
{
    public partial class App : Application
    {
        public static Usuario Usuario { get; set; }
        public static SQLiteConnection ConexaoSqlite { get; set; }
        public static IServicoConfiguracaoApp ServicoConfiguracaoApp { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            ServicoConfiguracaoApp = DependencyService.Get<IServicoConfiguracaoApp>();
            await InicializaConexaoSqlite();

            bool existeUsuario = ExisteUsuarioLogado();

            if (existeUsuario)
            {
                MainPage = new NavigationPage(new pgHomePage(true, true));
            }
            else
            {
                MainPage = new NavigationPage(new pgLogin());

            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static void Logout()
        {
            try
            {
                UsuariosAppBusiness usuariosAppBusiness = new UsuariosAppBusiness();
                usuariosAppBusiness.Excluir(Usuario.Id);
                Usuario = new Usuario();

                App.Current.MainPage = new NavigationPage(new pgLogin());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task InicializaConexaoSqlite()
        {
            try
            {
                if (Device.RuntimePlatform == Device.UWP)
                {
                    ConexaoSqlite = await ServicoConfiguracaoApp.GetSQLiteConnectionAsync();
                }
                else
                {
                    ConexaoSqlite = ServicoConfiguracaoApp.GetSQLiteConnection();
                }

                ConexaoSqlite.CreateTable<Usuario>();

            }
            catch (Exception ex)
            {
                await MainPage.DisplayAlert("Erro", "Erro ao iniciar conexão: " + ex.Message, "Ok");
            }
        }

        private bool ExisteUsuarioLogado()
        {
            try
            {

                UsuariosAppBusiness usuarioBusiness = new UsuariosAppBusiness();

                Usuario = usuarioBusiness.GetUsuario();

                if (Usuario == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

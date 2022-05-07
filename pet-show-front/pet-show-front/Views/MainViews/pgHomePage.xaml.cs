using pet_show_front.Business.ApiBusiness;
using pet_show_front.Business.AppBusiness;
using pet_show_front.Interfaces;
using pet_show_front.Models.MainModels;
using pet_show_front.Views.Custom;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pet_show_front.Views.MainViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pgHomePage : pgBasePage
    {
        bool CarregouPage = false;
        public pgHomePage(bool atualizaUsuario, bool atualizaFuncoes)
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!CarregouPage)
            {
                await InicializaPage();
                CarregouPage = true;
            }

        }

        private void ExibeLoading(bool exibir)
        {
            stkLoading.IsVisible = exibir;
            stkMenu.IsVisible = !exibir;
        }

        private async Task InicializaPage()
        {
            try
            {
                AlteraLabelNomeUsuario();

                ExibeLoading(true);

                InicializaMenu();


                ExibeLoading(false);
            }
            catch (Exception ex)
            {
                ExibeLoading(false);
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private void AlteraLabelNomeUsuario()
        {
            lblUsuario.Text = App.Usuario.Nome.Split(' ')[0];
        }

        private void InicializaMenu()
        {
            try
            {
                stkMenu.Children.Add(new pgBotaoMenu(new MenuApp()
                {
                    Opcao = 1,
                    Descricao = "Produção",
                    Icone = "checklistProduct.png",
                    IdFuncao = 1

                }));

                stkMenu.Children.Add(new pgBotaoMenu(new MenuApp()
                {
                    Opcao = 2,
                    Descricao = "Separação",
                    Icone = "agruparcarga.png",
                    IdFuncao = 2

                }));

                stkMenu.Children.Add(new pgBotaoMenu(new MenuApp()
                {
                    Opcao = 3,
                    Descricao = "Etiquetas",
                    Icone = "printer_new.png",
                    IdFuncao = 3
                }));

                stkMenu.Children.Add(new pgBotaoMenu(new MenuApp()
                {
                    Opcao = 4,
                    Descricao = "Transferências",
                    Icone = "exchange.png",
                    IdFuncao = 4

                }));

                stkMenu.Children.Add(new pgBotaoMenu(new MenuApp()
                {
                    Opcao = 99,
                    Descricao = "Configurações",
                    Icone = "configuracoes.png"

                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height && Device.RuntimePlatform != Device.UWP)
            {
                stkLogo.IsVisible = false;
            }
            else
            {
                stkLogo.IsVisible = true;
            }


        }

        private async void Sair_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (await App.Current.MainPage.DisplayAlert("Atenção", "Deseja realmente sair?", "Sim", "Não"))
                {
                    App.Logout();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Erro ao tocar em sair: " + ex.Message, "ok");
            }

        }

        private async void UsuarioLabel_Tapped(object sender, EventArgs e)
        {
            try
            {
                var retorno = await DisplayActionSheet("Escolha uma opção", "cancelar", null, "Atualizar funções", "Sair do App");

                if (!string.IsNullOrEmpty(retorno) || retorno == "cancelar")
                {
                    if (retorno == "Sair do App")
                    {
                        App.Logout();
                    }
                    else
                    {
                        ExibeLoading(true);

                        ExibeLoading(false);
                    }
                }
            }
            catch (Exception ex)
            {
                ExibeLoading(false);
                await DisplayAlert("Erro", "Erro ao tocar em usuário: " + ex.Message, "ok");
            }
        }
    }
}
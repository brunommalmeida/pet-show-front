using pet_show_front.Business.AppBusiness;
using pet_show_front.Models.MainModels;
using pet_show_front.Views.Checklists;
using pet_show_front.Views.MainViews;
using pet_show_front.Views.Romaneios;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pet_show_front.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pgBotaoMenu : ContentView
    {
        public MenuApp Menu { get; set; }
        public bool clicou { get; set; }

        public pgBotaoMenu(MenuApp menu)
        {
            InitializeComponent();

            Menu = menu;
            lblMenu.Text = Menu.Descricao;
            icone.Source = Menu.Icone;
        }

        private async void Menu_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (clicou)
                {
                    return;
                }

                clicou = true;

                await AnimaFrame();

                clicou = false;

                if (Menu.Opcao == 1)
                {
                    await Navigation.PushAsync(new Views.Romaneios.pgListaRomaneios());
                }
                else if (Menu.Opcao == 2)
                {
                    await Navigation.PushAsync(new pgChecklists());

                }
                else if (Menu.Opcao == 99)
                {
                    await Navigation.PushAsync(new pgConfiguracoes());
                }
                clicou = false;
            }
            catch (Exception ex)
            {
                clicou = false;
                await App.Current.MainPage.DisplayAlert("Erro", "Erro ao abrir menu: " + ex.Message, "Ok");
            }
        }

        private async Task AnimaFrame()
        {
            try
            {
                uint duracaoAnimacao = 80;
                //aumenta o frame
                var scaleUpAnimationTask = frmBotao.ScaleTo(1.2, duracaoAnimacao);

                // deixa transparente
                var fadeOutAnimationTask = frmBotao.FadeTo(0, duracaoAnimacao);

                // executa elas
                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);

                // volta ao normal
                var scaleDownAnimationTask = frmBotao.ScaleTo(1, duracaoAnimacao);

                // volta o normal a opacidade
                var fadeInAnimationTask = frmBotao.FadeTo(1, duracaoAnimacao);

                // executa
                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
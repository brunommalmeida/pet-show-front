using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pet_show_front.Views.MainViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pgSolicitarPermissoes : ContentPage
    {
        ActivityIndicator aiLoading = new ActivityIndicator();
        public pgSolicitarPermissoes()
        {
            InitializeComponent();
            aiLoading.IsRunning = true;
            aiLoading.IsEnabled = true;
            aiLoading.IsVisible = false;
            aiLoading.BindingContext = this;
            aiLoading.Color = Color.Black;

            stkPage.Children.Add(aiLoading);
        }

        private void HabilitaIndicator(bool bHabilita)
        {
            lblInfo.IsVisible = !bHabilita;
            btnGravarPermissoes.IsVisible = !bHabilita;
            aiLoading.IsVisible = bHabilita;
        }

        private void VoltarPageInicial()
        {
            try
            {
                App.Current.MainPage = new NavigationPage(new pgHomePage(true, true));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void BtnGravarPermissoes_Clicked(object sender, EventArgs e)
        {
            try
            {
                PermissionStatus permissaoCamera = PermissionStatus.Unknown;
                bool negouPermissao = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera);
                HabilitaIndicator(true);
                try
                {
                    if (negouPermissao)
                    {
                        await DisplayAlert("Atenção", "A permissão de câmera já foi negada. Fique atento a próxima solicitação e autorize o acesso à câmera.", "Ok");
                    }

                    permissaoCamera = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();

                }
                catch (Exception ex)
                {
                    if (!ex.Message.Contains("task was canceled"))
                    {
                        throw;
                    }
                }

                if (permissaoCamera != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permissão", "Você deve conceder as permissões para o aplicativo funcionar corretamente!", "Ok");
                    HabilitaIndicator(false);
                }
                else
                {

                    VoltarPageInicial();
                }

            }
            catch (Exception ex)
            {
                HabilitaIndicator(false);
                await DisplayAlert("Erro", "Erro: " + ex.Message, "Ok");
            }
        }
    }
}
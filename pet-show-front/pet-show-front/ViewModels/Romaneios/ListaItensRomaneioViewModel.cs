using pet_show_front.Business.ApiBusiness;
using pet_show_front.Model;
using pet_show_front.Views.Romaneios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Romaneios
{
    public class ListaItensRomaneioViewModel : BaseViewModel
    {
        public ICommand PesquisarCommand { get; private set; }
        public ICommand SepararCommand { get; private set; }

        ObservableCollection<ItemRomaneio> itensRomaneio = null;
        string textoPesquisaRomaneio = "";
        public string TextoPesquisaRomaneio
        {
            get
            {
                return textoPesquisaRomaneio;
            }
            set
            {
                textoPesquisaRomaneio = value;

                if (string.IsNullOrEmpty(TextoPesquisaRomaneio) || string.IsNullOrWhiteSpace(TextoPesquisaRomaneio))
                {
                    PesquisarCommand.Execute(null);
                }
            }
        }

        public ObservableCollection<ItemRomaneio> ItensRomaneio
        {
            get
            {
                return itensRomaneio;
            }
            set
            {
                itensRomaneio = value;
                OnPropertyChanged();
            }
        }

        public ListaItensRomaneioViewModel(Model.Romaneio romaneio)
        {

            Task.Run(async () => await GetItensRomaneioAsync(romaneio.Id));
        }

        public ListaItensRomaneioViewModel()
        {

        }

        private async Task GetItensRomaneioAsync(int idRomaneio)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                RomaneiosApiBusiness romaneiosApiBusiness = new RomaneiosApiBusiness();
                ItensRomaneio = new
                     ObservableCollection<ItemRomaneio>(await romaneiosApiBusiness.GetItensRomaneiosAsync(idRomaneio.ToString()));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                throw ex;
            }

            IsBusy = false;
        }

        private async void SepararRomaneioAsync(Romaneio romaneio)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                //talvez possa usar a própria instância de romaneio para manipular a tela seguinte
                RomaneiosApiBusiness romaneiosApiBusiness = new RomaneiosApiBusiness();
                var itensRomaneio = await romaneiosApiBusiness.GetRomaneiosAsync(textoPesquisaRomaneio);
                //await App.Current.MainPage.Navigation.PushAsync(new pgListaItensRomaneio());
                App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 2]);

            }
            catch (Exception ex)
            {
                App.ConexaoSqlite.Rollback();
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }

            IsBusy = false;
        }
    }
}

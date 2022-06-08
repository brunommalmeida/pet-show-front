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
        public ICommand SepararItemRomaneioCommand { get; private set; }

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
            SepararItemRomaneioCommand = new Command<ItemRomaneio>(SepararItemRomaneioAsync);

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

        private async void SepararItemRomaneioAsync(ItemRomaneio itemRomaneio)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                //talvez possa usar a própria instância de romaneio para manipular a tela seguinte
                await App.Current.MainPage.Navigation.PushAsync(new pgRomaneio(itemRomaneio));

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

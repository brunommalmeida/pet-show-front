using pet_show_front.Business.ApiBusiness;
using pet_show_front.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Romaneios
{
    public class RomaneioViewModel : BaseViewModel
    {
        public ICommand EnviarRomaneioCommand { get; set; }
        public ICommand LimparCommand { get; set; }
        public ItemRomaneio ItemRomaneio { get; set; }
        public RomaneioViewModel(Model.ItemRomaneio itemRomaneio)
        {
            ItemRomaneio = itemRomaneio;
            EnviarRomaneioCommand = new Command(EnviarRomaneioAsync);
        }

        public RomaneioViewModel()
        {

        }
        private async void EnviarRomaneioAsync()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                if (string.IsNullOrEmpty(ItemRomaneio.lote))
                {
                    await App.Current.MainPage.DisplayAlert("Atenção", "Preencha o campo lote", "Ok");
                    IsBusy = false;
                    return;
                }
                if(ItemRomaneio.quantidade == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Atenção", "Quantidade deve ser maior que 0", "Ok");
                    IsBusy = false;
                    return;
                }
                RomaneiosApiBusiness romaneiosApiBusiness = new RomaneiosApiBusiness();
                await romaneiosApiBusiness.EnviarRomaneioAsync(ItemRomaneio);
                IsBusy = false;
                await App.Current.MainPage.Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                throw ex;
            }

            IsBusy = false;
        }

    }
}

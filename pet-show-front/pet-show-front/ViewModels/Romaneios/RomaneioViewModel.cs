using pet_show_front.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Romaneios
{
    public class RomaneioViewModel
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

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

using pet_show_front.Droid.Services;
using SQLite;
using System;
using Xamarin.Forms;
using pet_show_front.Interfaces;
using System.Threading.Tasks;

[assembly: Dependency(typeof(ServicoConfiguracaoApp))]
namespace pet_show_front.Droid.Services
{
    public class ServicoConfiguracaoApp : IServicoConfiguracaoApp
    {
        public SQLiteConnection GetSQLiteConnection()
        {
            try
            {
                var filename = "PetShowDataBase.db3";
                var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = System.IO.Path.Combine(documentspath, filename);

                return new SQLiteConnection(path);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Task<SQLiteConnection> GetSQLiteConnectionAsync()
        {
            throw new NotImplementedException();
        }
        public int GetAndroidVersion()
        {
            return (int)Android.OS.Build.VERSION.SdkInt;
        }
    }
}
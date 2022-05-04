using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pet_show_front.Interfaces
{
    public interface IServicoConfiguracaoApp
    {
        SQLiteConnection GetSQLiteConnection();

        Task<SQLiteConnection> GetSQLiteConnectionAsync();

        int GetAndroidVersion();

    }
}

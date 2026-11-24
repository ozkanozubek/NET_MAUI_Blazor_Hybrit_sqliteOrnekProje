using SQLite;
using sqliteOrnekProje.Models;

namespace sqliteOrnekProje.Services
{
    public class IletisimService
    {
        private SQLiteAsyncConnection? _dbConnection;

        private async Task InitAsync()
        {
            if (_dbConnection is not null)
                return;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "personel.db");
            _dbConnection = new SQLiteAsyncConnection(dbPath);
            await _dbConnection.CreateTableAsync<IletisimBilgisi>();
        }

        public async Task<List<IletisimBilgisi>> GetIletisimListByTcAsync(string tc)
        {
            await InitAsync();
            return await _dbConnection!.Table<IletisimBilgisi>()
                .Where(x => x.Tc == tc)
                .ToListAsync();
        }

        public async Task SaveIletisimAsync(IletisimBilgisi iletisim)
        {
            await InitAsync();
            if (iletisim.Id > 0)
                await _dbConnection!.UpdateAsync(iletisim);
            else
                await _dbConnection!.InsertAsync(iletisim);
        }

        public async Task DeleteIletisimAsync(IletisimBilgisi iletisim)
        {
            await InitAsync();
            await _dbConnection!.DeleteAsync(iletisim);
        }
    }
}
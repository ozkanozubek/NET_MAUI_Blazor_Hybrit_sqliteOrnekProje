using SQLite;
using sqliteOrnekProje.Models; // Models klasöründeki TemelBilgi modeline ulaşabilmek için

namespace sqliteOrnekProje.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? _dbConnection;   //Veritabanı işlemlerini uygulamayı dondurmadan (asenkron/async) yürütmek için kullanılan bağlantı nesnesidir.

    // Veritabanı bağlantısını başlatan ve tablo yoksa oluşturan metod
    private async Task InitAsync()
    {
        if (_dbConnection is not null)
            return;

        // Cihazın güvenli uygulama depolama alanına veritabanı dosya yolunu belirliyoruz
        //Uygulamanın çalıştığı cihazda (Windows, Android, iOS) veritabanı dosyasının (personel.db) güvenle saklanacağı özel klasör yolunu verir.
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "personel.db");

        _dbConnection = new SQLiteAsyncConnection(dbPath);

        // temelbilgiler tablosunu yoksa oluşturur (varsa dokunmaz)
        //Model sınıfına bakar; veritabanında temelbilgiler tablosu yoksa otomatik oluşturur, varsa mevcut tabloya dokunmaz.
        await _dbConnection.CreateTableAsync<TemelBilgi>();
    }

    // 1. TÜM KAYITLARI GETİR
    
    public async Task<List<TemelBilgi>> GetAllAsync()   //Tablodaki tüm kayıtları C# List<TemelBilgi> listesi olarak çeker.
    {
        await InitAsync();
        return await _dbConnection!.Table<TemelBilgi>().ToListAsync();
    }

    // 2. TEK BİR KAYDI TC KİMLİK NUMARASINA GÖRE GETİR
    public async Task<TemelBilgi?> GetByTcAsync(string tc)
    {
        await InitAsync();
        return await _dbConnection!.Table<TemelBilgi>()
                                   .Where(x => x.Tc == tc)
                                   .FirstOrDefaultAsync();     //.Where(x => x.Tc == tc) şartı ile sadece girilen TC'ye ait tek bir kaydı getirir.
    }

    // 3. YENİ KAYIT EKLE VEYA VARSA GÜNCELLE
    public async Task<int> SaveAsync(TemelBilgi kisi)
    {
        await InitAsync();

        // Önce girilen TC veritabanında var mı kontrol ediyoruz
        var existingPerson = await GetByTcAsync(kisi.Tc);

        if (existingPerson != null)
        {
            // Kayıt zaten varsa Güncelle
            return await _dbConnection!.UpdateAsync(kisi);
        }
        else
        {
            // Kayıt yoksa Yeni Ekle
            return await _dbConnection!.InsertAsync(kisi);
        }
    }

    // 4. KAYIT SİL
    public async Task<int> DeleteAsync(TemelBilgi kisi)
    {
        await InitAsync();
        return await _dbConnection!.DeleteAsync(kisi);
    }
}


/*
 Servis Katmanı (DatabaseService.cs)
Veritabanı bağlantısını ve tüm veri işlemlerini yönetir.

SQLiteAsyncConnection _dbConnection: Veritabanı işlemlerini uygulamayı dondurmadan (asenkron/async) yürütmek için kullanılan bağlantı nesnesidir.

FileSystem.AppDataDirectory: Uygulamanın çalıştığı cihazda (Windows, Android, iOS) veritabanı dosyasının (personel.db) güvenle saklanacağı özel klasör yolunu verir.

CreateTableAsync<TemelBilgi>(): Model sınıfına bakar; veritabanında temelbilgiler tablosu yoksa otomatik oluşturur, varsa mevcut tabloya dokunmaz.

GetAllAsync(): Tablodaki tüm kayıtları C# List<TemelBilgi> listesi olarak çeker.

GetByTcAsync(string tc): .Where(x => x.Tc == tc) şartı ile sadece girilen TC'ye ait tek bir kaydı getirir.

SaveAsync(TemelBilgi kisi):

Önce GetByTcAsync ile TC'nin veritabanında olup olmadığını kontrol eder.

Varsa UpdateAsync ile mevcut kaydı günceller.

Yoksa InsertAsync ile yeni kayıt ekler.

DeleteAsync(TemelBilgi kisi): Nesneyi veritabanından siler.

3. Bağımlılık Enjeksiyonu (MauiProgram.cs)
builder.Services.AddSingleton<DatabaseService>();: DatabaseService sınıfını uygulamaya tanıtır. Singleton yapısı sayesinde uygulama çalıştığı sürece hafızada tek bir servis örneği tutulur ve tüm sayfalar aynı veritabanı bağlantısını kullanır.
 */
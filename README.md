# .NET MAUI Blazor Hybrid SQLite Örneği

Bu proje, **.NET 10**, **.NET MAUI**, **Blazor Hybrid** ve **SQLite** kullanarak çalışan bir personel ve iletişim bilgileri örnek uygulamasıdır. Visual Studio 2026 ile Windows, Android, iOS ve Mac Catalyst platformlarında geliştirilmek üzere hazırlanmıştır.

## Özellikler

- SQLite üzerinde `temelbilgiler` ve `iletisimbilgileri` tablolarını oluşturma
- T.C. Kimlik numarasına göre personel kaydetme ve güncelleme
- Personel bilgilerini listeleme ve arama
- SQLite veritabanına iletişim bilgileri ekleme
- Blazor Razor bileşenlerini .NET MAUI penceresinde görüntüleme
- Windows, Android, iOS ve Mac Catalyst hedefleri

## Gereksinimler

Aşağıdaki araçların bilgisayarınızda kurulu olması gerekir:

- Visual Studio 2026
- **.NET MAUI** iş yükü
- **.NET 10 SDK**
- Android için Android SDK ve en az bir emülatör veya fiziksel cihaz
- Windows için Windows 10/11 ve Windows App SDK geliştirme araçları

Visual Studio Installer'da şu bileşenlerin seçili olduğundan emin olun:

- `.NET Multi-platform App UI development`
- İlgili platform için `Android SDK & tools`
- Windows geliştiriyorsanız Windows 10/11 SDK bileşenleri

## Depoyu Klonlama

```bash
git clone https://github.com/ozkanozubek/NET_MAUI_Blazor_Hybrit_sqliteOrnekProje.git
cd NET_MAUI_Blazor_Hybrit_sqliteOrnekProje
```

Alternatif olarak GitHub'daki **Code → Download ZIP** seçeneğiyle indirebilirsiniz.

## Projeyi Çalıştırma

1. Visual Studio 2026'yı açın.
2. **Open a project or solution** seçeneğine tıklayın.
3. İndirdiğiniz klasördeki [`sqliteOrnekProje.slnx`](sqliteOrnekProje.slnx) dosyasını açın.
4. Üst araç çubuğunda hedef cihazı seçin:
   - Windows Machine
   - Android Emülatörü veya Android cihaz
   - iOS/Mac Catalyst yapılandırması
5. **F5** tuşuna basın veya **Start Debugging** düğmesini kullanın.

Visual Studio ilk açılışta NuGet paketlerini otomatik olarak geri yükleyebilir. Geri yükleme tamamlanmazsa terminal veya Paket Yöneticisi Konsolundan çalıştırın:

```bash
dotnet restore sqliteOrnekProje.slnx
```

## SQLite Veritabanı

Veritabanı, projede depoya eklenmiş sabit bir dosya olarak gelmez. Uygulama ilk çalıştığında veritabanı cihazın özel uygulama depolama alanında otomatik olarak oluşturulur:

```text
personel.db
```

Veritabanı dosyasının yolu uygulama tarafından `FileSystem.AppDataDirectory` kullanılarak belirlenir.

İlk başlatmada şu tablolar oluşturulur:

- `temelbilgiler`: T.C., ad, soyad ve eğitim durumu
- `iletisimbilgileri`: T.C., GSM, iş telefonu ve e-posta bilgileri

Uygulamayı kaldırmak veya verilerini sıfırlamak için cihazdaki uygulama verilerini temizleyin veya uygulamayı kaldırıp yeniden kurun.

## Komut Satırından Çalıştırma

Windows hedefinde örnek olarak:

```bash
dotnet restore sqliteOrnekProje.slnx
dotnet build sqliteOrnekProje/sqliteOrnekProje.csproj -f net10.0-windows10.0.19041.0
dotnet run --project sqliteOrnekProje/sqliteOrnekProje.csproj -f net10.0-windows10.0.19041.0
```

Android için Visual Studio'da Android emülatörünü veya cihazı seçmek, özellikle Android SDK yapılandırması açısından daha kolaydır.

## Proje Yapısı

```text
sqliteOrnekProje/
├── Components/       Razor bileşenleri ve sayfaları
├── Models/           SQLite tablo modelleri
├── Platforms/        Android, iOS, Mac Catalyst ve Windows ayarları
├── Resources/        Simge, görsel, yazı tipi ve splash ekran dosyaları
├── Services/         SQLite ve iletişim veri servisleri
├── wwwroot/          Blazor web dosyaları ve Bootstrap kaynakları
├── App.xaml          MAUI uygulama tanımı
├── MainPage.xaml     WebView ana uygulama sayfası
└── MauiProgram.cs    BAĞLANTILAR ve MAUI başlatma yapılandırması
```

## Sık Karşılaşılan Sorular

### `net10.0-*` hedeflerini bulamıyorum

Visual Studio Installer içinde `.NET 10 SDK` ve `.NET MAUI` bileşenlerinin kurulu olduğundan emin olun. Ardından `dotnet --version` komutuyla SDK sürümünü kontrol edin.

### Android üzerinde çalıştırılamıyor

Android emülatörünün başlatılmış veya fiziksel cihazın USB hata ayıklama modunda olduğunu kontrol edin. Visual Studio'da hedef olarak doğru Android cihazı seçilmelidir.

### iOS veya Mac Catalyst hedefleri görünmüyor

Bu hedefler Mac ortamında desteklenir. Windows'ta iOS derlemesi için uygun uzak Mac bağlantısı ve Apple geliştirme hesaplamaları kurulmuş olmalıdır.

## Lisans

Bu depo için lisans dosyası eklenmemiştir. Kodların kullanımı veya dağıtımı öncesinde deponun sahibiyle iletişime geçin.

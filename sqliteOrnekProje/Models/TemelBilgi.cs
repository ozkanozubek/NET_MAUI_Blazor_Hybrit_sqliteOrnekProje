using SQLite;

namespace sqliteOrnekProje.Models;

[Table("temelbilgiler")] // C# sınıfını SQLite veritabanındaki "temelbilgiler" tablosuyla eşleştirir.
public class TemelBilgi
{
    [PrimaryKey] // TC alanını Birincil Anahtar yaptık
    public string Tc { get; set; } = string.Empty;

    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public string EgitimDurumu { get; set; } = string.Empty;
}

/*
 1. Model Katmanı (TemelBilgi.cs)
TemelBilgi.cs kodları veritabanındaki temelbilgiler tablosunu C# nesnesine dönüştürür.

[Table("temelbilgiler")]: C# sınıfını SQLite veritabanındaki "temelbilgiler" tablosuyla eşleştirir.

[PrimaryKey]: Tc alanının tablonun birincil anahtarı (benzersiz kimliği) olduğunu belirtir.

public string Tc { get; set; } = string.Empty;: Tablodaki sütunları temsil eden C# özellikleridir (Properties). string.Empty değeri, varsayılan olarak boş metin atayarak C# null hatalarını engeller.
*/
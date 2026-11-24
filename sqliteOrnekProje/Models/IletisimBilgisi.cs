using SQLite;

namespace sqliteOrnekProje.Models
{
    [Table("iletisimbilgileri")]
    public class IletisimBilgisi
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed] // Arama performansını artırmak için TC alanını indeksliyoruz
        public string Tc { get; set; } = string.Empty; // Yabancı Anahtar (Foreign Key)

        public string GsmNo { get; set; } = string.Empty;

        public string? IsTel { get; set; } // Boş bırakılabilir (Nullable)

        public string Eposta { get; set; } = string.Empty;
    }
}
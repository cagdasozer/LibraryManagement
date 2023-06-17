using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class OduncAlan
    {
        public int OduncAlanId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ad { get; set; }
        [Required]
        [MaxLength(50)]
        public string Soyad { get; set; }
        [Required]
        [MaxLength(11)]
        public string TCKimlikNo { get; set; }
        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }
        [Required]
        public DateTime OduncAlmaTarihi { get; set; }
        public DateTime? GeriDonusTarihi { get; set; }

    }
}

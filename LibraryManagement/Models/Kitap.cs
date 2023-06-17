using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Kitap
    {
        public int KitapId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ISBN { get; set; }
        public DateTime? GeriDonusTarihi { get; set; }
    }
}

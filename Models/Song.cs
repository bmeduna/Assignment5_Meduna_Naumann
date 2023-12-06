using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment5_Meduna_Naumann.Models
{
    public class Song
    {
        public int Id { get; set; }
        //Title
        [Display(Name = "Title")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string? title { get; set; }
        //Release Date
        [Display(Name = "Released")]
        [DataType(DataType.Date)]
        public DateTime? release_date { get; set; }
        //Genre
        [Display(Name = "Genre")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string? genre { get; set; }
        //Artist
        [Display(Name = "Artist")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string? artist { get; set; }
        //Price
        [Display(Name = "Price")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? price { get; set; }
    }
}

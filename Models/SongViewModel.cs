using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment5_Meduna_Naumann.Models
{
    public class SongViewModel
    {
        public List<Song>? songs { get; set; }
        public SelectList? genres { get; set; }
        public SelectList? artists { get; set; }
        public string? view_genre { get; set; }
        public string? view_artist { get; set;}
    }
}

namespace MusicShop.Domain.Models.Albums
{
    public class Genre
    {
        public string GenreCode { get; set; }

        public string GenreName { get; set; } = string.Empty;

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}

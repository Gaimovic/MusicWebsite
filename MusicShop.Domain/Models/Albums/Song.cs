namespace MusicShop.Domain.Models.Albums
{
    public class Song
    {
        public Guid SongId { get; set; }

        public string SongName { get; set; } = string.Empty;

        public Guid AlbumId { get; set; }
    }
}

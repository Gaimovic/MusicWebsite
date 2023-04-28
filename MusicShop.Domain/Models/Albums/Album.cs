namespace MusicShop.Domain.Models.Albums
{
    public class Album
    {
        public Guid AlbumId { get; set; }

        public string Title { get; set; }

        public Guid AuthorId { get; set; }

        public string Description { get; set; }

        public Guid PortfolioId { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();

        public Guid CoverId { get; set; }
        public Cover Cover { get; set;}

        public string GenreCode { get; set; }
        public Genre Genre { get; set; }
    }
}

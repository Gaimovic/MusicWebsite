namespace MusicShop.Domain.Models.Albums
{
    public class Author
    {
        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string MusicBandName { get; set; }

        public string Email { get; set; }
    }
}

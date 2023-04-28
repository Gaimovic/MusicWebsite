using MusicShop.Domain.Models.Albums;

namespace MusicShop.Domain.Models.Concerts
{
    public class Concert
    {
        public Guid ConcertId { get; set; }

        public string ConcertTitle { get; set; }

        public string ConcertDescription { get; set; }

        public DateTime ConcertStartDate { get; set; }

        public DateTime ConcertEndDate { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

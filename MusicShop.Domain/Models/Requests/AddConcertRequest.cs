namespace MusicShop.Domain.Models.Requests
{
    public class AddConcertRequest
    {
        public Guid AuthorId { get; set; }
        public DateTime ConcertStartDate { get; set; }
        public DateTime ConcertEndDate { get; set; }
        public string ConcertTitle { get; set; }
        public string ConcertDescription { get; set; }
    }
}

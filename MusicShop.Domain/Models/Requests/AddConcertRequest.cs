namespace MusicShop.Domain.Models.Requests
{
    public class AddConcertRequest
    {
        public string Author { get; set; }
        public DateTime ConcertStartDate { get; set; }
        public DateTime ConcertEndDate { get; set; }
        public string ConcertTitle { get; set; }
        public string ConcertDescription { get; set; }
        public string Email { get; set; }
    }
}

namespace MusicShop.Domain.Models.Requests
{
    public class CreateAlbumRequest
    {
        public string Author {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverUrl { get; set; }
        public string GenreCode { get; set; }
        public string MusicBandName { get; set; }
        public List<string> Songs { get; set; }
    }
}

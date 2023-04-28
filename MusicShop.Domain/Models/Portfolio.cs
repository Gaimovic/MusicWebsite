using MusicShop.Domain.Models.Albums;

namespace MusicShop.Domain.Models
{
    public class Portfolio
    {
        public Guid PortfolioId { get; set; }

        public string? PortfolioName { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();

        public Guid UserId { get; set; }
    }
}

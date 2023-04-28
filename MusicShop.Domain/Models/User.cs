namespace MusicShop.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<Portfolio> Portfolios { get; set; }
    }
}

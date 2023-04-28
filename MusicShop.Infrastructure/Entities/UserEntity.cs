using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Infrastructure.Entities
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<PortfolioEntity> Portfolios { get; set; }
    }
}

using MusicShop.Infrastructure.Entities.Albums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Infrastructure.Entities
{
    [Table("Portfolio")]
    public class PortfolioEntity
    {
        [Key]
        public Guid PortfolioId { get; set; }

        public string? PortfolioName { get; set; }

        public List<AlbumEntity> Albums { get; set; } = new List<AlbumEntity>();

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}

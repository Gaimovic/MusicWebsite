using MusicShop.Infrastructure.Entities.Concerts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Infrastructure.Entities.Albums
{
    [Table("Author")]
    public class AuthorEntity
    {
        [Key]
        public Guid AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public string Email { get; set; }

        public List<ConcertEntity> Concerts { get; set; } = new List<ConcertEntity>();
    }
}

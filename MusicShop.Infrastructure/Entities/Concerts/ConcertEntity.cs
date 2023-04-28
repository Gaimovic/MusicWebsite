using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MusicShop.Infrastructure.Entities.Albums;

namespace MusicShop.Infrastructure.Entities.Concerts
{
    [Table("Concert")]
    public class ConcertEntity
    {
        [Key]
        public Guid ConcertId { get; set; }

        [Required]
        public string ConcertTitle { get; set; }

        public string ConcertDescription { get; set; }

        public DateTime ConcertStartDate { get; set; }

        public DateTime ConcertEndDate { get; set; }

        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public AuthorEntity Author { get; set; }
    }
}

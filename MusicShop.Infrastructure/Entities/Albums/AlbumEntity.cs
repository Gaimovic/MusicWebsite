using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Infrastructure.Entities.Albums
{
    [Table("Album")]
    public class AlbumEntity
    {
        [Key]
        public Guid AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public AuthorEntity Author { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid PortfolioId { get; set; }
        [ForeignKey(nameof(PortfolioId))]
        public PortfolioEntity Portfolio { get; set; }

        public List<SongEntity> Songs { get; set; } = new List<SongEntity>();

        public Guid CoverId { get; set; }
        [ForeignKey(nameof(CoverId))]
        public CoverEntity Cover { get; set; }

        public string GenreCode { get; set; }
        [ForeignKey(nameof(GenreCode))]
        public GenreEntity Genre { get; set; }
    }
}

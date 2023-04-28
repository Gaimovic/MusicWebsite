using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Infrastructure.Entities.Albums
{
    [Table("Song")]
    public class SongEntity
    {
        [Key]
        public Guid SongId { get; set; }

        public string SongName { get; set; } = string.Empty;

        public Guid AlbumId { get; set; }
        [ForeignKey(nameof(AlbumId))]
        public AlbumEntity Album { get; set; }
    }
}

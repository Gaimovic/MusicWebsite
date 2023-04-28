using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Infrastructure.Entities.Albums
{
    [Table("Genre")]
    public class GenreEntity
    {
        [Key]
        public string GenreCode { get; set; }

        [Required]
        public string GenreName { get; set; }
    }
}

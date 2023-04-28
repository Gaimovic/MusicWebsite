using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Infrastructure.Entities.Albums
{
    [Table("Cover")]
    public class CoverEntity
    {
        [Key]
        public Guid CoverGuid { get; set; }

        public string? Url { get; set; }
    }
}

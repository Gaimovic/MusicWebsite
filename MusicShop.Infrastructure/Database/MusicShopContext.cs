using Microsoft.EntityFrameworkCore;
using MusicShop.Infrastructure.Entities;
using MusicShop.Infrastructure.Entities.Albums;
using MusicShop.Infrastructure.Entities.Concerts;

namespace MusicShop.Infrastructure.Database
{
    public class MusicShopContext : DbContext
    {

        public MusicShopContext(DbContextOptions<MusicShopContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PortfolioEntity> Portfolios { get; set; }

        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<SongEntity> Songs { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<ConcertEntity> Concerts { get; set; }
        public DbSet<CoverEntity> Covers { get; set; }
    }
}

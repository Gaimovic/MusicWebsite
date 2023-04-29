using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Models.Albums;
using MusicShop.Infrastructure.Database;
using MusicShop.Infrastructure.Entities.Albums;

namespace MusicShop.Infrastructure.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbums();
        Task<Album> GetAlbum(string albumTitle);

        Task<Guid> AddAlbum(Album album);
        Task RemoveAlbum(Guid concertGuid);
        Task<List<Guid>> AddSongList(List<Song> songs);
    }

    public class AlbumRepository : IAlbumRepository
    {
        private MusicShopContext _musicShopContext;
        private readonly IMapper _mapper;

        public AlbumRepository(MusicShopContext musicShopContext, IMapper mapper) {
            _musicShopContext = musicShopContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var albums = await _musicShopContext
                .Albums
                .Include(x => x.Songs)
                .Include(x => x.Cover)
                .Include(x => x.Author)
                .AsNoTracking()
                .ToListAsync();

            return albums
                .Select(x => _mapper.Map<Album>(x));
        }

        public async Task<Album> GetAlbum(string albumTitle)
        {
            var album = await _musicShopContext
                .Albums
                .Include(x => x.Songs)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Title == albumTitle);

            return _mapper.Map<Album>(album);
        }

        public async Task<Guid> AddAlbum(Album album)
        {
            var entity = _mapper.Map<AlbumEntity>(album);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return entity.AlbumId;
        }

        public async Task RemoveAlbum(Guid albumGuid)
        {
            var itemToDelete = new AlbumEntity
            {
                AlbumId = albumGuid
            };

            var songsToRemove = await _musicShopContext
                .Songs
                .AsNoTracking()
                .Where(x => x.AlbumId == albumGuid)
                .ToListAsync();

            _musicShopContext.Albums.Remove(itemToDelete);
            _musicShopContext.Songs.RemoveRange(songsToRemove);

            await _musicShopContext.SaveChangesAsync();
        }

        public async Task<List<Guid>> AddSongList(List<Song> songs)
        {
            var entities = songs.Select(x => _mapper.Map<SongEntity>(x));

            await _musicShopContext.AddRangeAsync(entities);
            await _musicShopContext.SaveChangesAsync();

            return entities.Select(x => x.SongId).ToList();
        }
    }
}

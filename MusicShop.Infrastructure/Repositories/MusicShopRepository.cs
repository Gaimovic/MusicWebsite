using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Models;
using MusicShop.Domain.Models.Albums;
using MusicShop.Domain.Models.Concerts;
using MusicShop.Infrastructure.Database;
using MusicShop.Infrastructure.Entities;
using MusicShop.Infrastructure.Entities.Albums;
using MusicShop.Infrastructure.Entities.Concerts;

namespace MusicShop.Infrastructure.Repositories
{
    // TODO Move to different repositories
    public interface IMusicShopRepository
    {
        Task<Genre> GetGenre(string genreCode);
        Task<User> GetUserByNameAndSurname(string userName, string userSurname);
        Task<Portfolio> GetPortfolio(string portfolioName);
        Task<Author> GetAuthorById(Guid authorId);
        Task<Author> GetAuthor(string authorName);
        Task<IEnumerable<Album>> GetAlbums();
        Task<Album> GetAlbum(string albumTitle);
        Task<IEnumerable<Concert>> GetAllConcertsByAuthorId(Guid authorId);
        Task<IEnumerable<Concert>> GetAllConcerts();

        Task<Guid> AddNewUser(string userName, string userSurname);
        Task<Author> AddNewAuthor(string authorName, string musicBandName);
        Task<Guid> AddNewPortfolio(Portfolio portfolio);
        Task<Genre> AddNewGenre(Genre genre);
        Task<Guid> AddNewSong(Song song);
        Task<Guid> AddAlbum(Album album);
        Task<Guid> AddConcert(Concert concert);
        Task<Cover> AddNewCover(Cover cover);
        Task<List<Guid>> AddSongList(List<Song> songs);

        Task RemoveConcert(Guid concertGuid);
        Task RemoveAlbum(Guid concertGuid);
        Task RemoveCover(Guid coverId);
    }

    public class MusicShopRepository : IMusicShopRepository
    {
        private MusicShopContext _musicShopContext;
        private readonly IMapper _mapper;

        public MusicShopRepository(MusicShopContext musicShopContext, IMapper mapper) {
            _musicShopContext = musicShopContext;
            _mapper = mapper;
        }

        public async Task<Genre> GetGenre(string genreCode)
        {
            var genre = await _musicShopContext
                .Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.GenreCode == genreCode);

            return _mapper.Map<Genre>(genre);
        }

        public async Task<Author> GetAuthor(string authorName)
        {
            var author = await _musicShopContext
                .Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.AuthorName == authorName);
            return _mapper.Map<Author>(author);
        }

        public async Task<Author> GetAuthorById(Guid authorId)
        {
            var author = await _musicShopContext
                .Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.AuthorId == authorId);
            return _mapper.Map<Author>(author);
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var albums = await _musicShopContext
                .Albums
                .Include(x => x.Songs)
                .Include(x => x.Cover)
                .AsNoTracking()
                .ToListAsync();

            return albums
                .Select(x => _mapper.Map<Album>(x));
        }

        public async Task<IEnumerable<Concert>> GetAllConcertsByAuthorId(Guid authorId)
        {
            var albums = await _musicShopContext
                .Concerts
                .AsNoTracking()
                .Where(x => x.AuthorId == authorId)
                .ToListAsync();

            return albums
                .Select(x => _mapper.Map<Concert>(x));
        }

        public async Task<IEnumerable<Concert>> GetAllConcerts()
        {
            var albums = await _musicShopContext
                .Concerts
                .AsNoTracking()
                .OrderBy(x => x.ConcertStartDate)
                .ToListAsync();

            return albums
                .Select(x => _mapper.Map<Concert>(x));
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

        public async Task<User> GetUserByNameAndSurname(string userName, string userSurname)
        {
            var user = await _musicShopContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == userName && x.Surname == userSurname);

            return _mapper.Map<User>(user);
        }

        public async Task<Portfolio> GetPortfolio(string portfolioName)
        {
            var portfolio = await _musicShopContext
                .Portfolios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PortfolioName == portfolioName);

            return _mapper.Map<Portfolio>(portfolio); ;
        }

        public async Task<Guid> AddNewUser(string userName, string userSurname)
        {
            var user = AddUser(userName, userSurname);
            await _musicShopContext.AddAsync(user);

            await _musicShopContext.SaveChangesAsync();

            return user.UserId;
        }

        public async Task<Author> AddNewAuthor(string authorName, string musicBandName)
        {
            var author = AddAuthor(authorName, musicBandName);
            await _musicShopContext.AddAsync(author);

            await _musicShopContext.SaveChangesAsync();

            return _mapper.Map<Author>(author);
        }

        public async Task<Guid> AddNewPortfolio(Portfolio portfolio)
        {
            var entity = _mapper.Map<PortfolioEntity>(portfolio);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return entity.PortfolioId;
        }

        public async Task<Cover> AddNewCover(Cover cover)
        {
            var entity = _mapper.Map<CoverEntity>(cover);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return _mapper.Map<Cover>(entity);
        }


        public async Task<Genre> AddNewGenre(Genre genre)
        {
            var entity = _mapper.Map<GenreEntity>(genre);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return genre;
        }

        public async Task<Guid> AddNewSong(Song song)
        {
            var entity = _mapper.Map<SongEntity>(song);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return entity.SongId;
        }

        public async Task<List<Guid>> AddSongList(List<Song> songs)
        {
            var entities = songs.Select(x => _mapper.Map<SongEntity>(x));

            await _musicShopContext.AddRangeAsync(entities);
            await _musicShopContext.SaveChangesAsync();

            return entities.Select(x => x.SongId).ToList();
        }

        public async Task<Guid> AddAlbum(Album album)
        {
            var entity = _mapper.Map<AlbumEntity>(album);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return entity.AlbumId;
        }

        public async Task<Guid> AddConcert(Concert concert)
        {
            var entity = _mapper.Map<ConcertEntity>(concert);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return entity.ConcertId;
        }

        public async Task RemoveConcert(Guid concertGuid)
        {
            var itemToDelete = new ConcertEntity
            {
                ConcertId = concertGuid
            };

            _musicShopContext.Concerts.Remove(itemToDelete);
            await _musicShopContext.SaveChangesAsync();
        }

        public async Task RemoveAlbum(Guid concertGuid)
        {
            var itemToDelete = new AlbumEntity
            {
                AlbumId = concertGuid
            };

            _musicShopContext.Albums.Remove(itemToDelete);
            await _musicShopContext.SaveChangesAsync();
        }

        public async Task RemoveCover(Guid coverId)
        {
            var itemToDelete = new CoverEntity
            {
                CoverGuid = coverId
            };

            _musicShopContext.Covers.Remove(itemToDelete);
            await _musicShopContext.SaveChangesAsync();
        }

        private UserEntity AddUser(string name, string surname)
        {
            return new UserEntity() { Name = name, Surname = surname };
        }

        private AuthorEntity AddAuthor(string name, string musicBandName)
        {
            return new AuthorEntity() { AuthorName = name, MusicBandName = musicBandName };
        }
    }
}

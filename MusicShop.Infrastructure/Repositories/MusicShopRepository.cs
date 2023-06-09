﻿using AutoMapper;
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
        Task<Author> GetAuthorByNameEmail(string name, string email);
        Task<Author> GetAuthorById(Guid authorId);
        Task<Author> GetAuthor(string authorName);

        Task<Guid> AddNewUser(string userName, string userSurname);
        Task<Author> CreateAuthor(string authorName, string email);
        Task<Guid> AddNewPortfolio(Portfolio portfolio);
        Task<Genre> AddNewGenre(Genre genre);
        Task<Guid> AddNewSong(Song song);
        Task<Cover> AddNewCover(Cover cover);
        Task<List<Guid>> AddSongList(List<Song> songs);
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

        public async Task<Author> GetAuthorByNameEmail(string name, string email)
        {
            var author = await _musicShopContext
                .Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.AuthorName == name && x.Email == email);
            return _mapper.Map<Author>(author);
        }

        public async Task<IEnumerable<Concert>> GetAllConcertsByAuthorId(Guid authorId)
        {
            var concerts = await _musicShopContext
                .Concerts
                .Include(x => x.Author)
                .AsNoTracking()
                .Where(x => x.AuthorId == authorId)
                .ToListAsync();

            return concerts
                .Select(x => _mapper.Map<Concert>(x));
        }

        public async Task<IEnumerable<Concert>> GetAllConcerts()
        {
            var concerts = await _musicShopContext
                .Concerts
                .Include(x => x.Author)
                .AsNoTracking()
                .OrderByDescending(x => x.ConcertStartDate)
                .ToListAsync();

            return concerts
                .Select(x => _mapper.Map<Concert>(x));
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

        public async Task<Author> CreateAuthor(string authorName, string email)
        {
            var author = await _musicShopContext
                .Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.AuthorName == authorName && x.Email == email);

            if (author != null)
                return _mapper.Map<Author>(author);

            author = new AuthorEntity() { AuthorName = authorName, Email = email }; ;
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
    }
}

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
    public interface IConcertRepository
    {
        Task<IEnumerable<Concert>> GetAllConcertsByAuthorId(Guid authorId);
        Task<IEnumerable<Concert>> GetAllConcerts();
        Task<Guid> AddConcert(Concert concert);

        Task RemoveConcert(Guid concertGuid);
    }

    public class ConcertRepository : IConcertRepository
    {
        private MusicShopContext _musicShopContext;
        private readonly IMapper _mapper;

        public ConcertRepository(MusicShopContext musicShopContext, IMapper mapper) {
            _musicShopContext = musicShopContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Concert>> GetAllConcertsByAuthorId(Guid authorId)
        {
            var albums = await _musicShopContext
                .Concerts
                .Include(x => x.Author)
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
                .Include(x => x.Author)
                .AsNoTracking()
                .OrderByDescending(x => x.ConcertStartDate)
                .ToListAsync();

            return albums
                .Select(x => _mapper.Map<Concert>(x));
        }

        public async Task<Cover> AddNewCover(Cover cover)
        {
            var entity = _mapper.Map<CoverEntity>(cover);

            await _musicShopContext.AddAsync(entity);
            await _musicShopContext.SaveChangesAsync();

            return _mapper.Map<Cover>(entity);
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
    }
}

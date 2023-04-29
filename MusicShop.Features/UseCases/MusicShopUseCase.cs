using FluentValidation;
using MusicShop.Domain.Classifires;
using MusicShop.Domain.Models;
using MusicShop.Domain.Models.Albums;
using MusicShop.Domain.Models.Concerts;
using MusicShop.Domain.Models.Requests;
using MusicShop.Features.Validators;
using MusicShop.Infrastructure.Repositories;

namespace MusicShop.Features.UseCases
{
    // TODO Implement authorization checks
    // TODO Move to different use case groups
    public interface IMusicShopUseCase
    {
        Task<Guid> CreateMockInMemoryDb();
        Task<List<Album>> GetAllAlbums();
        Task<Guid> CreateUser(string name, string surname);
        Task<Guid> CreatePortfolio(string portfolioName, Guid userId);

        Task<Guid> CreateAlbum(CreateAlbumRequest request);
        Task RemoveAlbum(Guid removeAlbumId);

        Task<List<Concert>> GetConcerts(string authorName);
        Task<List<Concert>> GetConcerts();
        Task<Guid> AddConcert(AddConcertRequest request);
        Task RemoveConcert(Guid removeConcert);
    }

    public class MusicShopUseCase : IMusicShopUseCase
    {
        private readonly IMusicShopRepository _musicShopRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IConcertRepository _concertRepository;

        // TODO Add validations
        public MusicShopUseCase(
            IMusicShopRepository musicShopRepository,
            IAlbumRepository albumRepository,
            IConcertRepository concertRepository)
        {
            _musicShopRepository = musicShopRepository;
            _albumRepository = albumRepository;
            _concertRepository = concertRepository;
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            return (await _albumRepository.GetAlbums()).ToList();
        }

        public async Task<Guid> CreateUser(string name, string surname) {
            return await _musicShopRepository.AddNewUser(name, surname);
        }

        public async Task<Guid> CreatePortfolio(string portfolioName, Guid userId)
        {
            return await _musicShopRepository.AddNewPortfolio(new Portfolio() { PortfolioName = portfolioName, UserId = userId });
        }

        public async Task<Guid> CreateAlbum(CreateAlbumRequest request)
        {
            //Validate request
            var validator = new CreateAlbumRequestValidator();
            await validator.ValidateAndThrowAsync(request);

            var portfolio = await _musicShopRepository.GetPortfolio("MyTestPortfolio1");
            // Check for author
            var author = await _musicShopRepository.GetAuthor(request.Author);
            if (author == null)
                author = await _musicShopRepository.CreateAuthor(request.Author, request.Email);

            var cover = await _musicShopRepository.AddNewCover(new Cover() { Url = request.CoverUrl });

            var album = new Album()
            {
                Description = request.Description,
                AuthorId = author.AuthorId,
                Title = request.Title,
                GenreCode = request.GenreCode,
                CoverId = cover.CoverGuid,
                PortfolioId = portfolio.PortfolioId
            };

            var albumId = await _albumRepository.AddAlbum(album);
            var songsToCreate = request.Songs?.Where(x => x != null).Select(x => new Song() { SongName = x, AlbumId = albumId })
                .ToList();

            if(songsToCreate != null && songsToCreate.Any())
                await _albumRepository.AddSongList(songsToCreate);

            return albumId;
        }

        public async Task RemoveAlbum(Guid removeAlbumId)
        {
            await _albumRepository.RemoveAlbum(removeAlbumId);
        }

        public async Task<List<Concert>> GetConcerts(string authorName)
        {
            var author = await _musicShopRepository.GetAuthor(authorName);
            return (await _concertRepository
                .GetAllConcertsByAuthorId(author.AuthorId))
                .ToList();
        }

        public async Task<List<Concert>> GetConcerts()
        {
            return (await _concertRepository
                .GetAllConcerts())
                .ToList();
        }

        public async Task<Guid> AddConcert(AddConcertRequest request)
        {
            var validator = new AddConcertRquestValidator();
            await validator.ValidateAndThrowAsync(request);

            var author = await _musicShopRepository.CreateAuthor(request.Author, request.Email);
            var concert = new Concert()
            {
                AuthorId = author.AuthorId,
                ConcertStartDate = request.ConcertStartDate,
                ConcertEndDate = request.ConcertEndDate,
                ConcertTitle = request.ConcertTitle,
                ConcertDescription = request.ConcertDescription,
            };

            return await _concertRepository.AddConcert(concert);
        }

        public async Task RemoveConcert(Guid removeConcert)
        {
             await _concertRepository.RemoveConcert(removeConcert);
        }

        // Create Mock DB Record
        public async Task<Guid> CreateMockInMemoryDb()
        {
            var name = "TestName";
            var surname = "TestSurname";

            var user = await _musicShopRepository.GetUserByNameAndSurname(name, surname);

            if (user == null)
            {
                var userId = await _musicShopRepository.AddNewUser(name, surname);
                var portfolioId = await _musicShopRepository.AddNewPortfolio(new Portfolio() { PortfolioName = "MyTestPortfolio1", UserId = userId });

                // Create author 
                var author = await _musicShopRepository.CreateAuthor("TestAuthor", "testemail@gmail.com");

                // Add Genres
                await _musicShopRepository.AddNewGenre(new Genre() { GenreCode = GenresCodes.Pop, GenreName = "Pop" });
                await _musicShopRepository.AddNewGenre(new Genre() { GenreCode = GenresCodes.Rock, GenreName = "Rock" });
                var genre =  await _musicShopRepository.GetGenre(GenresCodes.HeavyMetal);
                if (genre == null)
                    genre = await _musicShopRepository.AddNewGenre(new Genre() { GenreCode = GenresCodes.HeavyMetal, GenreName = "Heavy Metal" });

                var cover = await _musicShopRepository.AddNewCover(new Cover() { Url = "https://indiater.com/wp-content/uploads/2021/06/Free-Music-Album-Cover-Art-Banner-Photoshop-Template.jpg" });
                // Add Album
                var albumId = await _albumRepository.AddAlbum(new Album() { 
                    PortfolioId = portfolioId, 
                    Description = "My new test portfolio", 
                    AuthorId = author.AuthorId, 
                    Title = "Test Title",
                    CoverId = cover.CoverGuid,
                    GenreCode = genre.GenreCode
                });

                // Add Songs
                await _musicShopRepository.AddNewSong(new Song() { SongName = "Two test songs", AlbumId = albumId });
                await _musicShopRepository.AddNewSong(new Song() { SongName = "Test question", AlbumId = albumId });

                return userId;
            }

            return user.UserId;
        }
    }
}

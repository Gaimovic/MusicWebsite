using Microsoft.AspNetCore.Mvc;
using MusicShop.Domain.Models.Albums;
using MusicShop.Domain.Models.Concerts;
using MusicShop.Domain.Models.Requests;
using MusicShop.Features.UseCases;
using System.Net.Mime;

namespace MusicShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicShopController : ControllerBase
    {
        private readonly IMusicShopUseCase _musicShopUseCase;

        public MusicShopController(IMusicShopUseCase musicShopUseCase)
        {
            _musicShopUseCase = musicShopUseCase;
        }

        [HttpGet]
        [Route("createdb")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Guid> CreateMockData()
        {
            var result = await _musicShopUseCase.CreateMockInMemoryDb();
            return result;
        }

        [HttpPost]
        [Route("createAlbum")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Guid> CreateAlbum(CreateAlbumRequest request)
        {
            return await _musicShopUseCase.CreateAlbum(request);
        }

        [HttpGet]
        [Route("getAllAlbums")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<List<Album>> GetAllAlbums()
        {
            return await _musicShopUseCase.GetAllAlbums();
        }

        [HttpGet]
        [Route("removeAlbum")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task DeleteAlbum(Guid albumId)
        {
            await _musicShopUseCase.RemoveAlbum(albumId);
            return;
        }

        [HttpGet]
        [Route("getConcerts")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<List<Concert>> GetConcert()
        {
            return await _musicShopUseCase.GetConcerts();
        }

        [HttpPost]
        [Route("addConcert")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Guid> AddConcert(AddConcertRequest request)
        {
            return await _musicShopUseCase.AddConcert(request);
        }

        [HttpGet]
        [Route("removeConcert")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task RemoveConcert(Guid concertId)
        {
            await _musicShopUseCase.RemoveConcert(concertId);
            return;
        }
    }
}

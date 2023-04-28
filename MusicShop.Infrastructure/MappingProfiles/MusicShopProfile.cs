using AutoMapper;
using MusicShop.Domain.Models;
using MusicShop.Domain.Models.Albums;
using MusicShop.Domain.Models.Concerts;
using MusicShop.Infrastructure.Entities;
using MusicShop.Infrastructure.Entities.Albums;
using MusicShop.Infrastructure.Entities.Concerts;

namespace MusicShop.Infrastructure.MappingProfiles
{
    public class MusicShopProfile : Profile
    {
        public MusicShopProfile()
        {
            CreateMap<AlbumEntity, Album>()
                .ReverseMap()
                .ForMember(dest => dest.Portfolio, opt => opt.Ignore())
                .ForMember(dest => dest.Author, opt => opt.Ignore());

            CreateMap<GenreEntity, Genre>()
                .ReverseMap();

            CreateMap<AuthorEntity, Author>()
                .ReverseMap();

            CreateMap<SongEntity, Song>()
                .ReverseMap()
                .ForMember(dest => dest.Album, opt => opt.Ignore());

            CreateMap<PortfolioEntity, Portfolio>()
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<UserEntity, User>()
                .ReverseMap();

            CreateMap<ConcertEntity, Concert>()
                .ReverseMap()
                .ForMember(dest => dest.Author, opt => opt.Ignore());

            CreateMap<CoverEntity, Cover>()
                .ReverseMap();
        }
    }
}

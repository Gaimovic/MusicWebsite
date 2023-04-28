using MusicShop.Domain.Models.Requests;
using MusicShop.Features.Validators.Common;

namespace MusicShop.Features.Validators
{
    public class CreateAlbumRequestValidator : UseCaseRequestValidatorBase<CreateAlbumRequest>
    {
        public CreateAlbumRequestValidator()
        {
            RuleForNullOrWhiteSpace(x => x.Title, nameof(CreateAlbumRequest.Title));
            RuleForNullOrWhiteSpace(x => x.Description, nameof(CreateAlbumRequest.Description));
            RuleForNullOrWhiteSpace(x => x.Email, nameof(CreateAlbumRequest.Email));
            RuleForNullOrWhiteSpace(x => x.Author, nameof(CreateAlbumRequest.Author));
            RuleForNullOrWhiteSpace(x => x.CoverUrl, nameof(CreateAlbumRequest.CoverUrl));
            RuleForNullOrWhiteSpace(x => x.GenreCode, nameof(CreateAlbumRequest.GenreCode));
        }
    }
}

using MusicShop.Domain.Models.Requests;
using MusicShop.Features.Validators.Common;

namespace MusicShop.Features.Validators
{
    public class AddConcertRquestValidator : UseCaseRequestValidatorBase<AddConcertRequest>
    {
        public AddConcertRquestValidator()
        {
            RuleForNullOrWhiteSpace(x => x.Author, nameof(AddConcertRequest.Author));
            RuleForNullOrWhiteSpace(x => x.ConcertDescription, nameof(AddConcertRequest.ConcertDescription));
            RuleForNullOrWhiteSpace(x => x.Email, nameof(AddConcertRequest.Email));
            RuleForNullOrWhiteSpace(x => x.ConcertTitle, nameof(AddConcertRequest.ConcertTitle));
        }
    }
}

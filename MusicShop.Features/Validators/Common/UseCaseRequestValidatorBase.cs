using FluentValidation;
using System.Linq.Expressions;

namespace MusicShop.Features.Validators.Common
{
    public abstract class UseCaseRequestValidatorBase<T> : AbstractValidator<T> where T : class, new()
    {
        public const string MandatoryFieldIsNotSetErrorCode = "mandatory_field_not_set";
        public string MandatoryFieldNotSetMessage(string fieldName) => $"{fieldName} is mandatory field";

        public string MaxCharacterMessage(string fieldName, int maxLenght) => $"{fieldName} cannot exceed {maxLenght} was not found";

        protected void RuleForNullOrWhiteSpace(Expression<Func<T, string>> expression, string propertyName)
        {
            RuleFor(expression)
                .Must(BeNotNullOrWhiteSpace)
                .WithMessage(x => MandatoryFieldNotSetMessage(propertyName))
                .WithErrorCode(MandatoryFieldIsNotSetErrorCode);
        }

        public bool BeNotNullOrWhiteSpace<TV>(TV inputValue)
        {
            return !Equals(inputValue, default(TV));
        }
    }
}

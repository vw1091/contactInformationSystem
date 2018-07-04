using FluentValidation;
using System.Text.RegularExpressions;
using System.Linq;
using BLL.Properties;

namespace BLL.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage(Resources.FirstName_Max).WithErrorCode(ResponseCodes.InvalidFirstName);
            RuleFor(x => x.FirstName).NotEmpty().Must(ContainsLetters).WithMessage(Resources.FirstName_Invalid).WithErrorCode(ResponseCodes.InvalidFirstName);

            RuleFor(x => x.LastName).MaximumLength(50).WithMessage(Resources.LastName_Max).WithErrorCode(ResponseCodes.InvalidLastName);
            RuleFor(x => x.LastName).NotEmpty().Must(ContainsLetters).WithMessage(Resources.LastName_Max).WithErrorCode(ResponseCodes.InvalidLastName);

            RuleFor(x => x.Email).MaximumLength(50).WithMessage(Resources.Email_Max).WithErrorCode(ResponseCodes.InvalidEmail);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(Resources.Email_Invalid).WithErrorCode(ResponseCodes.InvalidEmail);

            RuleFor(x => x.PhoneNumber).Length(10).WithErrorCode(ResponseCodes.InvalidPhone).NotEmpty().Must(ContainsDigits).WithMessage(Resources.Phone_Invalid).WithErrorCode(ResponseCodes.InvalidPhone);
        }

        private bool ContainsLetters(string value)
        {
            return value.All(x => char.IsLetter(x));
        }

        private bool ContainsDigits(string value)
        {
            return value.All(x => char.IsDigit(x));
        }
    }
}

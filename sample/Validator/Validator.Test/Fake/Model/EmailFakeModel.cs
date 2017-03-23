using Validator.Core.Attribute.Validation;

namespace Validator.Test.Fake.Model
{
    class EmailFakeModel
    {
        [EmailValidate(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}

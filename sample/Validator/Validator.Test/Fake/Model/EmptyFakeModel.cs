using Validator.Core.Attribute.Validation;

namespace Validator.Test.Fake.Model
{
    class EmptyFakeModel
    {
        [EmptyValidate(ErrorMessage = "This field is required.")]
        public string Value { get; set; }
    }
}

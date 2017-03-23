using Validator.Core.Attribute.Validation;

namespace Validator.Test.Fake.Model
{
    class RangeFakeModel
    {
        [RangeValidate(Min = 0, Max = 100, ErrorMessage = "Please enter a number between 0 and 100.")]
        public int Value { get; set; }
    }
}

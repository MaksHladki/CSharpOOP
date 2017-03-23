using System.Collections.Generic;
using Validator.Core.Attribute.Validation;

namespace Validator.Test.Fake.Model
{
    class CollectionMinLengthFakeModel
    {
        [CollectionMinLengthValidate(MinLength = 3, ErrorMessage = "The collection should not be empty.")]
        public ICollection<int> Collection { get; set; }
    }

    class PseudoCollectionMinLengthFakeModel
    {
        [CollectionMinLengthValidate(MinLength = 3, ErrorMessage = "The collection should not be empty.")]
        public int Value { get; set; }
    }
}

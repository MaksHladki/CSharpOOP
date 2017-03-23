using System;
using System.Collections;
using Validator.Core.ModelResult;

namespace Validator.Core.Attribute.Validation
{
    public class CollectionMinLengthValidateAttribute : BaseValidateAttribute
    {
        public UInt32 MinLength { get; set; }

        public override IPropertyError Validate(object propValue)
        {
            var validationError = BuildErrorMessage(propValue);

            if (propValue == null) return validationError;

            var ienumerable = propValue as IEnumerable;
            if (ienumerable == null) return validationError;

            var count = 0;
            var enumerator = ienumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                count++;
                if (count >= MinLength) return null;
            }

            return validationError;
        }
    }
}

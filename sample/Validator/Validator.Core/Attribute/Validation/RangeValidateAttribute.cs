using System;
using Validator.Core.ModelResult;

namespace Validator.Core.Attribute.Validation
{
    public class RangeValidateAttribute : BaseValidateAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override IPropertyError Validate(object propValue)
        {
            var validationError = BuildErrorMessage(propValue);

            if (propValue == null) return validationError;

            var strValue = propValue.ToString();
            int intValue;
            if (!Int32.TryParse(strValue, out intValue)) return validationError;

            return (intValue >= Min && intValue <= Max) ? null : validationError;
        }
    }
}

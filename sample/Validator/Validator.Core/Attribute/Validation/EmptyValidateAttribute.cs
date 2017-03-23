using Validator.Core.ModelResult;

namespace Validator.Core.Attribute.Validation
{
    public class EmptyValidateAttribute : BaseValidateAttribute
    {
        public override IPropertyError Validate(object propValue)
        {
            var validationError = BuildErrorMessage(propValue);

            if (propValue == null) return validationError;

            var strValue = propValue as string;
            return string.IsNullOrWhiteSpace(strValue) ? validationError : null;
        }
    }
}

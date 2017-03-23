using System.Collections.Generic;

namespace Validator.Core.ModelResult
{
    public class ValidationResult : IValidationResult
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public IList<IPropertyError> Errors { get; set; }
    }
}

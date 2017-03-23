using System.Collections.Generic;

namespace Validator.Core.ModelResult
{
    public interface IValidationResult
    {
        string Name { get; set; }

        string DisplayName { get; set; }

        IList<IPropertyError> Errors { get; set; }
    }
}

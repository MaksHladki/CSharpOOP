using System.Collections.Generic;
using Validator.Core.ModelResult;

namespace Validator.Core.ModelState
{
    public interface IModelState : IReadOnlyDictionary<string, IValidationResult>
    {
        bool IsValid { get; }

        IEnumerable<string> GetErrors();
    }
}

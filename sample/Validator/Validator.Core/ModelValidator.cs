using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator.Core.Attribute.Validation;
using Validator.Core.Extension;
using Validator.Core.ModelResult;
using Validator.Core.ModelState;

namespace Validator.Core
{
    public static class ModelValidator
    {
        public static IModelState Validate(object model)
        {
            if (model == null) throw new ArgumentNullException("The model can not be null");

            var modelErrors = new List<IValidationResult>();

            foreach (var pair in GetValidationAttributes(model))
            {
                var prop = pair.Key;
                var attributes = pair.Value;
                var propErrors = new List<IPropertyError>();

                foreach (var attribute in attributes)
                {
                    var propValue = prop.GetValue(model);
                    var validationResult = attribute.Validate(propValue);
                    if (validationResult != null)
                    {
                        propErrors.Add(validationResult);
                    }
                }

                if (!propErrors.Any()) continue;

                var displayName = prop.GetDisplayName();
                modelErrors.Add(new ValidationResult
                {
                    DisplayName = displayName,
                    Name = prop.Name,
                    Errors = propErrors.ToList()
                });
            }

            return new ModelState.ModelState(modelErrors);
        }

        private static Dictionary<PropertyInfo, IList<BaseValidateAttribute>> GetValidationAttributes(object model)
        {
            var modelType = model.GetType();
            var dictAttrs = new Dictionary<PropertyInfo, IList<BaseValidateAttribute>>();

            foreach (PropertyInfo prop in modelType.GetProperties())
            {
                var attributes = prop.GetValidationAttributes();
                if (attributes.Any())
                {
                    dictAttrs.Add(prop, attributes.ToList());
                }
            }

            return dictAttrs;
        }
    }
}

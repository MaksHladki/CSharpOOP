using System;
using Validator.Core.ModelResult;

namespace Validator.Core.Attribute.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public abstract class BaseValidateAttribute : System.Attribute
    {
        #region Properties

        public string ErrorMessage { get; set; }

        #endregion

        #region Methods

        public abstract IPropertyError Validate(object propValue);

        public virtual bool IsValid(object propValue)
        {
            return Validate(propValue) == null;
        }

        protected virtual IPropertyError BuildErrorMessage(object propValue)
        {
            return new PropertyError
            {
                ErrorMessage = ErrorMessage,
                RawValue = propValue
            };
        }

        #endregion
    }
}

namespace Validator.Core.ModelResult
{
    public class PropertyError : IPropertyError
    {
        public string ErrorMessage { get; set; }

        public object RawValue { get; set; }
    }
}

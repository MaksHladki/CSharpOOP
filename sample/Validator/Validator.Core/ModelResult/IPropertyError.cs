namespace Validator.Core.ModelResult
{
    public interface IPropertyError
    {
        string ErrorMessage { get; set; }

        object RawValue { get; set; }
    }
}

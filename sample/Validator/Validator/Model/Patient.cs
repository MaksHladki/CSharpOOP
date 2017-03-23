using System.Collections.Generic;
using Validator.Core.Attribute;
using Validator.Core.Attribute.Validation;

namespace Validator.UI.Model
{
    public class Patient
    {
        [Display(Name = "First Name")]
        [EmptyValidate(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [EmptyValidate(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }

        [Display(Name = "Age")]
        [RangeValidate(Min = 0, Max = 100, ErrorMessage = "Please enter a number between 0 and 100.")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [EmptyValidate(ErrorMessage = "This field is required.")]
        [EmailValidate(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Display(Name = "List of symptoms")]
        [CollectionMinLengthValidate(MinLength = 2, ErrorMessage = "The list should not be empty.")]
        public IList<string> Symptoms { get; set; }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator.Core;
using Validator.Test.Fake.Model;

namespace Validator.Test.Attribute.Validation
{
    [TestClass]
    public class RangeValidateAttributeTests
    {
        [TestMethod]
        public void ValidateTest_Positive()
        {
            var model = new RangeFakeModel
            {
                Value = 50
            };

            var modelState = ModelValidator.Validate(model);
            Assert.IsTrue(modelState.IsValid);
        }

        [TestMethod]
        public void ValidateTest_Negative()
        {
            var model = new RangeFakeModel
            {
                Value = 111 // range validation error
            };

            var modelState = ModelValidator.Validate(model);
            Assert.IsFalse(modelState.IsValid);
        }
    }
}
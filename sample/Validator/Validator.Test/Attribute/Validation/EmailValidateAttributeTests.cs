using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator.Core;
using Validator.Test.Fake.Model;

namespace Validator.Test.Attribute.Validation
{
    [TestClass]
    public class EmailValidateAttributeTests
    {
        [TestMethod]
        public void ValidateTest_Positive()
        {
            var model = new EmailFakeModel
            {
                Email = "test.test@test.com"
            };

            var modeState = ModelValidator.Validate(model);
            Assert.IsTrue(modeState.IsValid);
        }

        [TestMethod]
        public void ValidateTest_Negative_IncorrectEmail()
        {
            var model = new EmailFakeModel
            {
                Email = "test.test@test"
            };

            var modeState = ModelValidator.Validate(model);
            Assert.IsFalse(modeState.IsValid);
        }

        [TestMethod]
        public void ValidateTest_Negative_EmptyValue()
        {
            var model = new EmailFakeModel
            {
                Email = string.Empty
            };

            var modeState = ModelValidator.Validate(model);
            Assert.IsFalse(modeState.IsValid);
        }
    }
}
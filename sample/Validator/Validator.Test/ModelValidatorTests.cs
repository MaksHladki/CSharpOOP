using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator.Core;
using Validator.Test.Fake.Model;

namespace Validator.Test
{
    [TestClass]
    public class ModelValidatorTests
    {
        [TestMethod]
        public void ValidateTest_Positive_Model()
        {
            var model = new EmailFakeModel
            {
                Email = "test@gmail.com"
            };

            var modelState = ModelValidator.Validate(model);
            Assert.IsTrue(modelState.IsValid);
        }

        [TestMethod]
        public void ValidateTest_Positive_EmptyObject()
        {
            try
            {
                var modelState = ModelValidator.Validate(new object());
                Assert.IsTrue(modelState.IsValid);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ValidateTest_Negative_Null()
        {
            try
            {
                var modelState = ModelValidator.Validate(null);
            }
            catch (ArgumentNullException)
            {
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
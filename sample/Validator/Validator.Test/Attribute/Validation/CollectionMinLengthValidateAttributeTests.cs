using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator.Core;
using Validator.Test.Fake.Model;

namespace Validator.Test.Attribute.Validation
{
    [TestClass]
    public class CollectionMinLengthValidateAttributeTests
    {
        [TestMethod]
        public void ValidateTest_Positive()
        {
            var model = new CollectionMinLengthFakeModel
            {
                Collection = Enumerable.Range(0, 10).ToList()
            };

            var modelState = ModelValidator.Validate(model);
            Assert.IsTrue(modelState.IsValid);
        }

        [TestMethod]
        public void ValidateTest_Negative_Null()
        {
            var model = new CollectionMinLengthFakeModel
            {
                Collection = null
            };

            var modelState = ModelValidator.Validate(model);
            Assert.IsFalse(modelState.IsValid);
        }

        [TestMethod]
        public void ValidateTest_Negative_MinLength()
        {
            var model = new CollectionMinLengthFakeModel
            {
                Collection = Enumerable.Range(0, 1).ToList()
            };

            var modelState = ModelValidator.Validate(model);
            Assert.IsFalse(modelState.IsValid);
        }

        [TestMethod]
        public void ValidateTest_Negative_IncorrectType()
        {
            var model = new PseudoCollectionMinLengthFakeModel
            {
                Value = 1
            };

            var modelState = ModelValidator.Validate(model);
            Assert.IsFalse(modelState.IsValid);
        }
    }
}
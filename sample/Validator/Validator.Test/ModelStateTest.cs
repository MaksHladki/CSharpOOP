using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator.Core;
using Validator.Core.ModelResult;
using Validator.Core.ModelState;
using Validator.Test.Fake.Model;

namespace Validator.Test
{
    [TestClass]
    public class ModelStateTest
    {
        [TestMethod]
        public void ConstructorTest_Positive()
        {
            ModelState modelState = new ModelState(new List<IValidationResult>());
            Assert.AreEqual(modelState.Count, 0);
        }

        [TestMethod]
        public void ConstructorTest_Negative_Null()
        {
            try
            {
                ModelState modelState = new ModelState(null);
            }
            catch (ArgumentNullException)
            {
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetEnumeratorTest()
        {
            var model = new PatientFakeModel
            {
                FirstName = "Erika",
                LastName = "Cole",
                Age = 106, //age validation error
                Email = "erika.cole37@example.com",
                Symptoms = new List<string>() //min lenght validation error
            };

            var modelState = ModelValidator.Validate(model);
            int countOfElements = 0;

            using (var enumerator = modelState.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    countOfElements++;
                }
            }

            Assert.AreEqual(countOfElements, 2);
        }

        [TestMethod]
        public void GetErrorsTest()
        {
            var model = new EmptyFakeModel
            {
                Value = string.Empty //empty validation error
            };

            var modelState = ModelValidator.Validate(model);

            Assert.AreEqual(modelState.GetErrors().Count(), 1);
        }

        [TestMethod]
        public void ContainsKeyTest()
        {
            var model = new CollectionMinLengthFakeModel
            {
                Collection = new List<int> {1, 2} //should use three or more elements
            };

            var modelState = ModelValidator.Validate(model);

            Assert.IsTrue(modelState.ContainsKey("Collection"));
        }

        [TestMethod]
        public void GetKeysTest()
        {
            var model = new PatientFakeModel
            {
                FirstName = "Erika",
                LastName = "Cole",
                Age = 106, //age validation error
                Email = "erika.cole37@example.com",
                Symptoms = new List<string>() //min lenght validation error
            };

            var modelState = ModelValidator.Validate(model);
            Assert.AreEqual(modelState.Keys.Count(), 2);
        }

        [TestMethod]
        public void GetItemTest_Positive()
        {
            var model = new PatientFakeModel
            {
                FirstName = string.Empty,//empty string validation error
                LastName = null,//empty string validation error
                Age = 50,
                Email = "alma.jenkins46@example.com",
                Symptoms = new List<string> { "symptom 1", "symptom 2", "symptom 3" }
            };

            var modelState = ModelValidator.Validate(model);

            Assert.AreEqual(modelState["FirstName"].Errors.Count, 1);
            Assert.AreEqual(modelState["LastName"].Errors.Count, 1);
        }

        [TestMethod]
        public void GetItemTest_Negative()
        {
            try
            {
                var model = new PatientFakeModel
                {
                    FirstName = string.Empty, //empty string validation error
                    LastName = null, //empty string validation error
                    Age = 50,
                    Email = "alma.jenkins46@example.com",
                    Symptoms = new List<string> {"symptom 1", "symptom 2", "symptom 3"}
                };

                var modelState = ModelValidator.Validate(model);
                var item = modelState["Email"];
            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TryGetValueTest()
        {
            var model = new PatientFakeModel
            {
                FirstName = "Erika",
                LastName = null,//empty validation error
                Age = 24,
                Email = "erika.cole37@example.com",
                Symptoms = new List<string> { "symptom 1", "symptom 2", "symptom 3" }
            };

            var modelState = ModelValidator.Validate(model);
            IValidationResult validationResult;

            if (modelState.TryGetValue("LastName", out validationResult))
            {
                if (validationResult == null || validationResult.Errors.Count == 0)
                    Assert.Fail();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}

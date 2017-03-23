using System;
using System.Collections.Generic;
using System.Linq;
using Validator.Core;
using Validator.UI.Model;

namespace Validator.UI
{
    class Program
    {
        static void Main()
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    FirstName = "Jane",
                    LastName = "Jimenez",
                    Age = 26,
                    Email = "jane.jimenez83@example.com",
                    Symptoms = new List<string> {"Back pain", "Ankle", "Food poisoning"}
                },
                new Patient
                {
                    FirstName = "Clyde",
                    Age = 101,
                    Email = "cl.com",
                    Symptoms = new List<string> {"Abdominal pain"}
                },
                new Patient
                {
                    LastName = ""
                }
            };

            for (int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine($"\nPatient #{i + 1}");
                var modelState = ModelValidator.Validate(patients[i]);
                if (modelState.IsValid)
                {
                    Console.WriteLine("No validation errors");
                    continue;
                }

                foreach (var validationResult in modelState.Values)
                {
                    Console.WriteLine($"Property \"{validationResult.DisplayName}\" has the following errors: ");
                    foreach (var error in validationResult.Errors.Select(er => er.ErrorMessage))
                    {
                        Console.WriteLine(error);
                    }
                }
            }
        }
    }
}

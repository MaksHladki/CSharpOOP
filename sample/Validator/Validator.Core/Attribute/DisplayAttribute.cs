using System;

namespace Validator.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DisplayAttribute : System.Attribute
    {
        public string Name { get; set; }
    }
}

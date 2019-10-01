using System.Collections.Generic;

namespace AutomationTest.Core.Validation
{
    public class ValidationGroup
    {
        public List<IValidatedProperty> Properties { get; } = new List<IValidatedProperty>();

        public ValidationGroup(params IValidatedProperty[] properties)
        {
            Properties.AddRange(properties);
        }

        public bool Validate()
        {
            var isGroupValid = true;

            foreach (var property in Properties)
            {
                if (!property.Validate())
                    isGroupValid = false;
            }

            return isGroupValid;
        }
    }
}

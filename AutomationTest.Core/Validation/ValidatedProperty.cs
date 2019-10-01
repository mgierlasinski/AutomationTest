using AutomationTest.Core.Validation.Rules;
using MvvmCross.ViewModels;
using System.Collections.Generic;

namespace AutomationTest.Core.Validation
{
    public class ValidatedProperty<T> : MvxNotifyPropertyChanged, IValidatedProperty
    {
        public List<IValidationRule<T>> Rules { get; } = new List<IValidationRule<T>>();

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value);
                Error = null;
            } 
        }

        private string _error;

        public string Error
        {
            get => _error;
            private set => SetProperty(ref _error, value);
        }

        public bool Validate()
        {
            foreach (var rule in Rules)
            {
                var result = rule.Validate(Value);

                if(!result.IsValid)
                {
                    Error = result.Error;
                    return false;
                }
            }
            
            return true;
        }
    }
}

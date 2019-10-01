namespace AutomationTest.Core.Validation
{
    public struct ValidationResult
    {
        public string Error { get; set; }

        public bool IsValid => string.IsNullOrWhiteSpace(Error);

        public static ValidationResult Success() => new ValidationResult
        {
            Error = string.Empty
        };

        public static ValidationResult Failed(string error) => new ValidationResult
        {
            Error = error
        };
    }
}

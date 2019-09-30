using System;

namespace AutomationTest.Core.Models
{
    public class PackageItem
    {
        public string Barcode { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}

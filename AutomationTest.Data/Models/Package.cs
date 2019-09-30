using Realms;
using System;

namespace AutomationTest.Data.Models
{
    public class Package : RealmObject
    {
        [PrimaryKey]
        public string Barcode { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        [Indexed]
        public DateTimeOffset Date { get; set; }
    }
}

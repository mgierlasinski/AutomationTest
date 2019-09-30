using Realms;
using System;

namespace AutomationTest.Data.Models
{
    public class Package : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Barcode { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}

using System;

namespace EurocomFontysHealth.Library.Entities
{
    public class Client
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
    }
    public enum Sex
    {
        Undefined,
        Male,
        Female
    }
}
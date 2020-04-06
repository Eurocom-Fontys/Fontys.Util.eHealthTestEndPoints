using System;

namespace EurocomFontysHealth.Library.Entities
{
    public class Client : Entity
    {
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
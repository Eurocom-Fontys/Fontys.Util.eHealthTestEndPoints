namespace EurocomFontysHealth.Library.Entities
{
    public class INRDevice : HealthDevice
    {
        public decimal TargetValue { get; set; }
        public decimal UpperBoundary { get; set; }
        public decimal LowerBoundary { get; set; }
    }
}
namespace BuildingManager.Models
{
    public class Building
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        public double GasPriced { get; set; }
        public double[] MonthlyGasUsage { get; set; }
        public string BuildingType { get; set; }
    }
}

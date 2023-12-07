namespace Domain.Models
{
    public class Building
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        public double GasPrice { get; set; }
        public List<double> MonthlyGasUsage { get; set; }
        public string BuildingType { get; set; }
    }
}

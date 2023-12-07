namespace Domain.Models
{
    public class Building
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        public double GasPrice { get; set; }
        public List<GasInfo> MonthlyGasUsage { get; set; }
        public BuildingType BuildingType { get; set; }
    }

    public class GasInfo
    {
        public double GasUsage { get; set; }
        public int Day { get; set; }
        public double OutTemp { get; set; }
        public double InnerTemp { get; set; }
    }

    public enum BuildingType
    {
        Building1, Redzicht, Greenveld
    }
}

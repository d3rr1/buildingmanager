namespace Data.Responses
{
    public class BuildingGreenveldInfoResponse
    {
        public string BuildingIdentifier { get; set; }
        public string Name { get; set; }
        public Floor[] Floors { get; set; }
    }

    public class Floor
    {
        public int FloorNumber { get; set; }
        public int NumberOfWorkplaces { get; set; }
    }
}

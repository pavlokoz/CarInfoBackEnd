namespace CarInfoModels.EntityModels
{
    public class Type
    {
        public short TypeId { get; set; }
        public string TypeName { get; set; }
        public CarType CarType { get; set; }
    }
}

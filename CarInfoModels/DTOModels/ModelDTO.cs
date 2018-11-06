using System.Collections.Generic;

namespace CarInfoModels.DTOModels
{
    public class ModelDTO
    {
        public long ModelId { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string AddInfo { get; set; }
        public string PhotoURL { get; set; }
        public short? TypeId { get; set; }
        public string TypeName { get; set; }
        public string CarTypeName { get; set; }
        public IList<string> Photos { get; set; }
        public IList<KeyValuePair<short?, string>> FuelTypes { get; set; }
    }
}

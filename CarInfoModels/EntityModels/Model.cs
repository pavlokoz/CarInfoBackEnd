using System.Collections.Generic;

namespace CarInfoModels.EntityModels
{
    public class Model
    {
        public long ModelId { get; set; }
        public string ModelName { get; set; }
        public string AddInfo { get; set; }
        public string PhotoURL { get; set; }
        public Brand Brand { get; set; }
        public Type Type { get; set; }
        public IList<string> Photos { get; set; }
        public IList<FuelType> FuelTypes { get; set; }
    }
}

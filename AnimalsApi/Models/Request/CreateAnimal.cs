using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Models.Request
{
    public class CreateAnimal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Birtday { get; set; }
        public object AnimalTypeId { get; internal set; }
        public DateTime Birthday { get; internal set; }
    }
}

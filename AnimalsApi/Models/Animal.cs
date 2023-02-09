using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public int AnimalType { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public object AnimalTypeId { get; internal set; }
    }
}

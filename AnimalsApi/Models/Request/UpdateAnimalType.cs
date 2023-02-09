using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Models.Request
{
    internal class UpdateAnimalType
    {
        public int AnimalTypeId { get; set; }
        public string? Type { get; set;}
    }
}

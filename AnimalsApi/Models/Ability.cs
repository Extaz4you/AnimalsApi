using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Models
{
    public class Ability
    {
        public int AbilityId { get; set; }
        public int AnimalTypeId { get; set; }
        public string CharAbility { get; set; }
    }
}

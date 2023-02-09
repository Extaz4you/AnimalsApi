using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Models
{
    public class AnimalAbility
    {
        public int AnimalAbilityId{ get; set; }
        public int AnimalId { get; set; }
        public int AbilityId { get; set; }
    }
}

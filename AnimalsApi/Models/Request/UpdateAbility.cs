using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Models.Request
{
    public class UpdateAbility
    {
        public int AbilityId { get; set; }
        public string CharAbility { get; set; }
    }
}

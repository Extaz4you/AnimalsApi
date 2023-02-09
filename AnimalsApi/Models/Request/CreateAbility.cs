using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Models.Request
{
    public class CreateAbility
    {
      public int AnimalTypeIid { get; set; }
      public string CharAbility { get; set;}

    }
}

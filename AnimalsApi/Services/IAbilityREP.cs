using AnimalsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Services
{
    public interface  IAbilityREP : IRepository<Ability, int>
    {
        IList<Ability> GetAllByAnimalTypeId(int id);
    }
}

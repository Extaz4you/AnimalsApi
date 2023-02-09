using AnimalsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Services
{
    public interface IAnimalAbilityREP
    {
        IList<AnimalAbility> GetAllByAnimalId(int id);
        IList<AnimalAbility> GetAllByAbilityId(int id);
        int Update(AnimalAbility animalAbility);
        int Delete(int animalAbilityId);
        object? GetAll();
        object? GetById(int animalAbilityId);
    }
}

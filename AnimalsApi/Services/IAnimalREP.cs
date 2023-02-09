using AnimalsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Services
{
    public interface IAnimalREP : IRepository<Animal, int>
    {
        IList<Animal> GetAllByAnimalType(int id);
    }
}

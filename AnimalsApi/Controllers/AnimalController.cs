using AnimalsApi.Models;
using AnimalsApi.Models.Request;
using AnimalsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Controllers
{
    public class AnimalControllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AnimalController : ControllerBase
        {
            private IAnimalREP _animalREP;

            public AnimalController(IAnimalREP animalREP)
            {
                _animalREP = animalREP;
            }

            [HttpPost("create")]
            [SwaggerOperation(OperationId = "CreateAnimal")]
            public ActionResult<int> Create([FromBody] CreateAnimal createRequest)
            {
                int res = _animalREP.Create(new Animal
                {
                    AnimalTypeId = createRequest.AnimalTypeId,
                    Name = createRequest.Name,
                    Birthday = createRequest.Birthday,
                    Description = createRequest.Description,
                });
                return Ok(res);
            }

            [HttpPut("update")]
            [SwaggerOperation(OperationId = "UpdateAnimal")]
            public ActionResult<int> Update([FromBody] UpdateAnimal updateRequest)
            {
                int res = _animalREP.Update(new Animal
                {
                    AnimalId = updateRequest.AnimalId,
                    Name = updateRequest.Name,
                    Birthday = updateRequest.Birthday,
                    Description = updateRequest.Description,
                });
                return Ok(res);
            }

            [HttpDelete("delete")]
            [SwaggerOperation(OperationId = "DeleteAnimal")]
            public ActionResult<int> Delete(int animalId)
            {
                int res = _animalREP.Delete(animalId);
                return Ok(res);
            }

            [HttpGet("get-all")]
            [SwaggerOperation(OperationId = "GetAllAnimals")]
            public ActionResult<List<Animal>> GetAll()
            {
                return Ok(_animalREP.GetAll());
            }

            [HttpGet("get-all-by-AnimalTypeId")]
            [SwaggerOperation(OperationId = "GetAllAnimalsByAnimalTypeId")]
            public ActionResult<List<Animal>> GetAllByAnimalTypeId(int id)
            {
                return Ok(_animalREP.GetAllByAnimalType(id));
            }

            [HttpGet("get-by-id")]
            [SwaggerOperation(OperationId = "GetAnimalById")]
            public ActionResult<Animal> GetById(int animalId)
            {
                return Ok(_animalREP.GetById(animalId));
            }
        }
    }
}

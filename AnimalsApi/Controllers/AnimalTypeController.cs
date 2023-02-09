using AnimalsApi.Models;
using AnimalsApi.Models.Request;
using AnimalsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : ControllerBase
    {
        private IAnimalTypeREP _animalTypeREP;

        public AnimalTypeController(IAnimalTypeREP animalTypeREP)
        {
            _animalTypeREP = animalTypeREP;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateAnimalType")]
        public ActionResult<int> Create([FromBody] CreateAnimalType createRequest)
        {
            int res = _animalTypeREP.Create(new AnimalType
            {
                Type = createRequest.Type,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateAnimalType")]
        public ActionResult<int> Update([FromBody] UpdateAnimalType updateRequest)
        {
            int res = _animalTypeREP.Update(new AnimalType
            {
                AnimalTypeId = updateRequest.AnimalTypeId,
                Type = updateRequest.Type,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteAnimalType")]
        public ActionResult<int> Delete(int AnimalTypeId)
        {
            int res = _animalTypeREP.Delete(AnimalTypeId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllAnimalType")]
        public ActionResult<List<AnimalType>> GetAll()
        {
            return Ok(_animalTypeREP.GetAll());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetAnimalTypeById")]
        public ActionResult<AnimalType> GetById(int AnimalTypeId)
        {
            return Ok(_animalTypeREP.GetById(AnimalTypeId));
        }
    }
}

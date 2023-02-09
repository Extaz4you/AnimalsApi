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
    public class AnimalAbilityController : ControllerBase
    {
        private IAnimalAbilityREP _animalAbilityREP;

        public AnimalAbilityController(IAnimalAbilityREP animalAbilityREP)
        {
            _animalAbilityREP = animalAbilityREP;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateAnimalAbility")]
        public ActionResult<int> Create([FromBody] CreateAnimalAbility createRequest)
        {
            int res = _animalAbilityREP.Create(new AnimalAbility
            {
                AnimalId = createRequest.AnimalId,
                AbilityId = createRequest.AbilityId,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateAnimalAbility")]
        public ActionResult<int> Update([FromBody] UpdateAnimalAbility updateRequest)
        {
            int res = _animalAbilityREP.Update(new AnimalAbility
            {
                AnimalAbilityId = updateRequest.AnimalAbilityId,
                AbilityId = updateRequest.AbilityId,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteAnimalAbility")]
        public ActionResult<int> Delete(int animalAbilityId)
        {
            int res = _animalAbilityREP.Delete(animalAbilityId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllAnimalAbility")]
        public ActionResult<List<AnimalAbility>> GetAll()
        {
            return Ok(_animalAbilityREP.GetAll());
        }

        [HttpGet("get-all-by-animal-id")]
        [SwaggerOperation(OperationId = "GetAllAnimalAbilityByAnimalId")]
        public ActionResult<List<AnimalAbility>> GetAllByAnimalId(int id)
        {
            return Ok(_animalAbilityREP.GetAllByAnimalId(id));
        }

        [HttpGet("get-all-by-Ability-id")]
        [SwaggerOperation(OperationId = "GetAllAnimalAbilityByAbilityId")]
        public ActionResult<List<AnimalAbility>> GetAllByAbilityId(int id)
        {
            return Ok(_animalAbilityREP.GetAllByAbilityId(id));
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetAnimaAbilityById")]
        public ActionResult<AnimalAbility> GetById(int animalAbilityId)
        {
            return Ok(_animalAbilityREP.GetById(animalAbilityId));
        }
    }
}

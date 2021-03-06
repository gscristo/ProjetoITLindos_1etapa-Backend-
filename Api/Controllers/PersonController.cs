using Api.Model;
using Api.Model.Person;
using Core.Infrastructure.Exceptions;
using Core.Person.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGetPersonById _getPersonById;
        private readonly IGetPersonByName _getPersonByName;
        private readonly IGetPersonByCpf _getPersonByCpf;
        private readonly IDeletePerson _deletePerson;
        private readonly IUpdatePerson _updatePerson;
        private readonly IGetAllPerson _getAllPerson;
        private readonly ICreatePerson _createPerson;


        public PersonController(IGetPersonById getPersonById,
                                  IDeletePerson deletePerson,
                                  IUpdatePerson updatePerson,
                                  IGetAllPerson getAllPerson,
                                  ICreatePerson createPerson,
                                  IGetPersonByName getPersonByName,
                                  IGetPersonByCpf getPersonByCpf)
        {
            _getPersonById = getPersonById;
            _deletePerson = deletePerson;
            _updatePerson = updatePerson;
            _getAllPerson = getAllPerson;
            _createPerson = createPerson;
            _getPersonByName = getPersonByName;
            _getPersonByCpf = getPersonByCpf;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> Get([FromBody] PaginationRequest paginationRequest)
        {
            try
            {
                var model = await _getAllPerson.Execute(paginationRequest.PageSize, paginationRequest.PageIndex, paginationRequest.Sort, paginationRequest.Direction);

                return Ok(Result.Create(model, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{personId}")]
        public async Task<IActionResult> GetId(Guid personId)
        {
            try
            {
                var result = await _getPersonById.Execute(personId);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("filter/{personByName}")]
        public async Task<IActionResult> GetName(string personByName)
        {
            try
            {
                var result = await _getPersonByName.Execute(personByName);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("filter/1/{personByCpf}")]
        public async Task<IActionResult> GetCpf(string personByCpf)
        {
            try
            {
                var result = await _getPersonByCpf.Execute(personByCpf);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePersonRequest updatePersonRequest)
        {
            try
            {
                var result = await _updatePerson.Execute(updatePersonRequest);

                return Ok(Result.Create(updatePersonRequest, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ApiDomainException domainException)
            {
                return BadRequest(Result.Create(domainException.Errors, HttpStatusCode.BadRequest, "Erro ao executar a operação"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePersonRequest createPersonRequest)
        {
            try
            {
                var result = await _createPerson.Execute(createPersonRequest);

                return Ok(Result.Create(result, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ApiDomainException domainException)
            {
                return BadRequest(Result.Create(domainException.Errors, HttpStatusCode.BadRequest, "Ops! Algo de errado aconteceu, verifique se o cpf digitado já existe nos registros e tente novamente."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{personId}")]
        public IActionResult Delete(Guid personId)
        {
            try
            {
                _deletePerson.Execute(personId);

                return Ok(Result.Create(personId, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

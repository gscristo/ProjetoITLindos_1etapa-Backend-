using Api.Model;
using Api.Model.Person;
using AutoMapper;
using Core.Infrastructure.Exceptions;
using Core.Person.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGetPersonById _getPersonById;
        private readonly IDeletePerson _deletePerson;
        private readonly IUpdatePerson _updatePerson;
        private readonly IGetAllPerson _getAllPerson;
        private readonly ICreatePerson _createPerson;

        public PersonController(IGetPersonById getPersonById, 
                                  IDeletePerson deletePerson, 
                                  IUpdatePerson updatePerson, 
                                  IGetAllPerson getAllPerson, 
                                  ICreatePerson createPerson)
        {
            _getPersonById = getPersonById;
            _deletePerson = deletePerson;
            _updatePerson = updatePerson;
            _getAllPerson = getAllPerson;
            _createPerson = createPerson;
        }

        [HttpPost("GetAll")]
        public async Task< IActionResult> Get([FromBody] PaginationRequest paginationRequest)
        {
            try
            {
                var model = await _getAllPerson.Execute(paginationRequest.PageSize, paginationRequest.PageIndex, paginationRequest.Sort, paginationRequest.Direction);

                return  Ok(Result.Create(model, HttpStatusCode.OK, "Operação executada com sucesso!"));
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
        public async Task< IActionResult> GetId(Guid personId)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Company;

namespace Agripoint.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// retorna todos os registros inseridos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyService.AllAsync();
                return Ok(companies);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Retorna um elemento específico.
        /// </summary>
        /// <param name="id">Id do tipo long a ser buscado na base de dados</param>
        /// <returns>Objeto contendo o registro buscado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(long id)
        {
            try
            {
                var model = await _companyService.GetAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Inserir o objeto na base de dados.
        /// </summary>
        /// <param name="model">Objeto para inserção na base de dados</param>
        /// <returns>Objeto contendo os dados recém adicionados.</returns>
        [HttpPost]
        public virtual async Task<IActionResult> InsertAsync([FromBody] CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            
            try
            {
                var newModel = await _companyService.InsertAsync(model);
                return Ok(newModel); 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        /// <summary>
        /// Atualiza o objeto na base de dados.
        /// </summary>
        /// <param name="model">Objeto para atualização na base de dados</param>
        /// <returns>Objeto contendo os dados recém atualizados.</returns>
        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            try
            {
                var newModel = await _companyService.UpdateAsync(model);
                return Ok(newModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Realiza o  delete na base de dados.
        /// </summary>
        /// <param name="id">Id do tipo long a ser realizado o  delete na base de dados</param>
        /// <returns>No Content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            try
            {
                await _companyService.DeleteAsync(id);
                return NoContent(); 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
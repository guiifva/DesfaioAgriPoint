using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SubscriptionsPlans;

namespace Agripoint.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SubscriptionsPlansController : ControllerBase
    {

        private readonly ISubscriptionPlansService _subscriptionPlanService;

        public SubscriptionsPlansController(ISubscriptionPlansService subscriptionPlanService)
        {
            _subscriptionPlanService = subscriptionPlanService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                var companies = await _subscriptionPlanService.AllAsync();
                return Ok(companies.OrderBy(x => x.Value));
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(long id)
        {
            try
            {
                var model = await _subscriptionPlanService.GetAsync(id);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public virtual async Task<IActionResult> InsertAsync([FromBody] SubscriptionsPlansViewModel model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            try
            {
                var newModel = await _subscriptionPlanService.InsertAsync(model);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] SubscriptionsPlansViewModel model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            try
            {
                var newModel = await _subscriptionPlanService.UpdateAsync(model);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            try
            {
                await _subscriptionPlanService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

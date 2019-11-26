using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModel.Order;

namespace Agripoint.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;
        private readonly ISubscriptionPlansService _subscriptionPlansService;
        private readonly ILogger _logger;

        public OrdersController(IOrdersService orderService,
                                ISubscriptionPlansService subscriptionPlansService,
                                ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
            _subscriptionPlansService = subscriptionPlansService;
        }

        /// <summary>
        /// retorna todos os registros inseridos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var companies = await _orderService.AllAsync();
                return Ok(companies);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// retorna se o usuario possui mais de uma assinatura
        /// <param name="userId">id do usuario</param>
        /// </summary>
        /// <returns> true or false</returns>
        [HttpGet("HasSubscribe/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ClientHasMoreThanOneSubscribe(Guid userId)
        {
            try
            {
                var userHasSubscribe = _orderService.ClientHasMoreThanOneOrder(userId.ToString());
                return Ok(userHasSubscribe);
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(long id)
        {
            try
            {
                var model = await _orderService.GetAsync(id);
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> InsertAsync([FromBody] OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            try
            {
                if (_orderService.ClientHasMoreThanOneOrder(model.UserId))
                {
                    _logger.LogWarning($"Usuario {model.UserId}, ja possui um plano e tentou assinar novamente outro plano");
                    return BadRequest("Cliente já possui uma assinatura!");
                }
                    

                var plan = await _subscriptionPlansService.GetAsync(model.SubscriptionPlanId);

                if (plan == null)
                {
                    _logger.LogWarning($"Usuario {model.UserId}, tentou fazer o pedido de um plano inexistente");
                    return BadRequest("Plano inexistente!");

                }
                _logger.LogWarning($"Usuario {model.UserId}, está fazendo o pedido do plano {model.SubscriptionPlanId}");

                var newModel = await _orderService.InsertWithPlanAsync(model, plan);
                _logger.LogWarning($"Usuario {model.UserId}, concluiu o pedido, pedido: {newModel.Id}, plano assinado: {newModel.SubscriptionPlanId}");

                return Ok(newModel);
            }
            catch (Exception e)
            {
                _logger.LogWarning($"Usuario {model.UserId}, teve um erro ao finalizar o pedido, erro: ${e.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        ///// <summary>
        ///// Atualiza o objeto na base de dados.
        ///// </summary>
        ///// <param name="model">Objeto para atualização na base de dados</param>
        ///// <returns>Objeto contendo os dados recém atualizados.</returns>
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public virtual async Task<IActionResult> UpdateAsync([FromBody] OrderViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return StatusCode(StatusCodes.Status400BadRequest);

        //    try
        //    {
        //        var newModel = await _orderService.UpdateAsync(model);
        //        return Ok(newModel);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //}

        /// <summary>
        /// Realiza o  delete na base de dados.
        /// </summary>
        /// <param name="id">Id do tipo long a ser realizado o  delete na base de dados</param>
        /// <returns>No Content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            try
            {
                await _orderService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
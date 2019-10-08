using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Order;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agripoint.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _service;
        private readonly ISubscriptionPlansService _subscriptionPlansService;

        public OrdersController(IOrdersService serviceOrder,
                                ISubscriptionPlansService subscriptionPlans)
        {
            _service = serviceOrder;
            _subscriptionPlansService = subscriptionPlans;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var subscriptionPlans = await _subscriptionPlansService.AllAsync();

            return View(subscriptionPlans);
        }

        public async Task<IActionResult> Subscription(long id)
        {
            var subscriptionPlan = await _subscriptionPlansService.GetAsync(id);

            if (subscriptionPlan == null)
                return NotFound();

            return View(subscriptionPlan);

        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.InsertAsync(model);
                    RedirectToRoute("/");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
                return BadRequest();
        }
    }
}

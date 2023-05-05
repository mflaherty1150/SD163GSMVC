using GSNet6.Data;
using GSNet6.Models.Customer;
using GSNet6.Services.Customer;
using Microsoft.AspNetCore.Mvc;

namespace GSNet6.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var customers = _service.GetAllCustomersAsync().Result;
            return View(customers);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }

            if (await _service.CreateCustomerAsync(model))
            {
                return Redirect(nameof(Index));
            }
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }
    }
}

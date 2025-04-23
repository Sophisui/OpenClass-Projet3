using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;

namespace P3AddNewFunctionalityDotNetCore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICart _cart;
        private readonly IOrderService _orderService;
        private readonly IStringLocalizer<OrderController> _localizer;
        private readonly IProductService _productService;

        public OrderController(ICart cart, IOrderService service, IStringLocalizer<OrderController> localizer, IProductService productService)
        {
            _cart = cart;
            _orderService = service;
            _localizer = localizer;
            _productService = productService;
        }

        public ViewResult Index()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel order)
        {
            if (!((Cart) _cart).Lines.Any())
            {
                ModelState.AddModelError("", _localizer["CartEmpty"]);
            }

            var products = _productService.GetAllProducts();
            foreach (var line in ((Cart)_cart).Lines)
            {
                ModelState.AddModelError("", _localizer[""]);
            }

            if (ModelState.IsValid)
            {
                order.Lines = ((Cart) _cart)?.Lines.ToArray();
                _orderService.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}

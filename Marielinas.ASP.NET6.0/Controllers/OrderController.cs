using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;
using Marielinas.ASP.NET6._0.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marielinas.ASP.NET6._0.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository OrderRepository, ShoppingCart ShoppingCart)
        {
            _orderRepository = OrderRepository;
            _shoppingCart = ShoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            if (_shoppingCart.ShoppingCartItems.Count < 1) 
            {
                ModelState.AddModelError("", "Shopping Cart is Empty for Order");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete() 
        {
            ViewBag.CheckoutCompleteMessage = "Order Placed successfully, Please comtinue shopping";
            return View();
        }

    }
}

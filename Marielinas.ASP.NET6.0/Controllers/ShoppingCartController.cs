using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Repository;
using Marielinas.ASP.NET6._0.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Marielinas.ASP.NET6._0.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IPieRepository _pieRepository;

        public ShoppingCartController(ShoppingCart ShoppingCart,IPieRepository PieRepository)
        {
            _shoppingCart = ShoppingCart;
            _pieRepository = PieRepository;
        }
        public IActionResult Index()
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;
            ShoppingCartViewModel cart = new ShoppingCartViewModel();
            cart.ShoppingCart = _shoppingCart;
            cart.ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal();
            return View(cart);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId) 
        {
            var pie = _pieRepository.GetPieById(pieId);

            if (pie != null)
            {
                _shoppingCart.AddToCart(pie, 1);
            }

            return RedirectToAction("Index");         
        }

        public RedirectToActionResult RemoveFromCart(int pieId) 
        {
            var pie = _pieRepository.GetPieById(pieId);
            if (pie != null)
            {
                _shoppingCart.RemoveFromCart(pie);
            }
            return RedirectToAction("Index");
        }
    }
}

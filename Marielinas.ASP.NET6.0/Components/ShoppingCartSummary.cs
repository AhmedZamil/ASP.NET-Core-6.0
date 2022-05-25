using Marielinas.ASP.NET6._0.Repository;
using Marielinas.ASP.NET6._0.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Marielinas.ASP.NET6._0.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart ShoppingCart)
        {
            _shoppingCart = ShoppingCart;
        }

        public IViewComponentResult Invoke() 
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            ShoppingCartViewModel cart = new ShoppingCartViewModel();

            cart.ShoppingCart = _shoppingCart;
            cart.ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal();


            return View(cart);
        }
    }
}

using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Marielinas.ASP.NET6._0.Repository
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext Context)
        {
            _context = Context;
        }

        public static ShoppingCart GetCart(IServiceProvider Services) 
        {
            ISession session = Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var cartId = session?.GetString("CartId")??Guid.NewGuid().ToString();
            session?.SetString("CartId",cartId);

            var context = Services.GetService<AppDbContext>();

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie, int amount)
        {
            var shoppingCartItems = _context.ShoppingCartItems.SingleOrDefault(p => p.Pie.PieId == pie.PieId && p.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItems == null)
            {
                var shoppingCartItem = new ShoppingCartItem()
                {
                    Pie = pie,
                    Amount = amount,
                    ShoppingCartId = ShoppingCartId
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else {
                shoppingCartItems.Amount++;
            }

            _context.SaveChanges();       
        }

        public void RemoveFromCart(Pie pie) 
        {
            var shoppingCartItems = _context.ShoppingCartItems.SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItems?.Amount > 1)
            {
                shoppingCartItems.Amount--;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItems);
            }
            _context.SaveChanges();       
        }

        public void ClearCart() 
        {
            var shoppingCartItems = _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).ToList();

            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);
            _context.SaveChanges();
        
        }

        public List<ShoppingCartItem> GetShoppingCartItems() 
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(p => p.Pie).ToList());     
        }

        public decimal GetShoppingCartTotal() 
        {
            var total = _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(p => p.Pie.Price * p.Amount).Sum();

            return total;
        }
    }
}

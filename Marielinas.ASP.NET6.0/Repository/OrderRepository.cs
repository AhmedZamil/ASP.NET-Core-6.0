using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;

namespace Marielinas.ASP.NET6._0.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext Context,ShoppingCart ShoppingCart)
        {
            _context = Context;
            _shoppingCart = ShoppingCart;
        }
        public void CreateOrder(Order order)
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in shoppingCartItems)
            {
                OrderDetail details = new OrderDetail();

                details.Amount = item.Amount;
                details.PieId = item.Pie.PieId;
                details.Price = item.Pie.Price;

                order.OrderDetails.Add(details);           
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}

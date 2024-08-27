

using Coffee_Shop_App.src.Entities;

namespace Coffee_Shop_App.src.Abstractions
{
    public interface IOrderRepository
    {
    public IEnumerable<Order> FindAll();

        public Order? findOne(string orderId);

        public Order CreateOne(Order order);

    }
}
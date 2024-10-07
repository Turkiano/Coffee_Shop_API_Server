

using Coffee_Shop_App.src.DTOs;
using Coffee_Shop_App.src.Entities;

namespace Coffee_Shop_App.src.Abstractions
{
    public interface IOrderItemRepository
    {
        public IEnumerable<OrderItem> FindAll(int limit, int offset);

   public OrderItem? findOne(Guid orderId, Guid productId); //targeting ids in params

        public OrderItem CreateOne(OrderItem orderItem);

            public OrderItem? findById(Guid orderItemId);



    }
}
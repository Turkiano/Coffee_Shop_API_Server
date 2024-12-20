using Coffee_Shop_App.src.Abstractions;
using Coffee_Shop_App.src.Databases;
using Coffee_Shop_App.src.DTOs;
using Coffee_Shop_App.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_App.Repositories;

public class OrderItemRepository : IOrderItemRepository
{

    private DatabaseContext _dbContext; //to get orders from the database

    // private DbSet<OrderItem> _orderItems; //to get orders as a list

    public OrderItemRepository(DatabaseContext dbcontext)
    {
        // _orderItems = databaseContext.OrderItems;
        _dbContext = dbcontext;
    }

    public OrderItem CreateOne(OrderItem orderItem)
    {
        _dbContext.Add(orderItem);
        _dbContext.SaveChanges();
        return orderItem;
    }

    public IEnumerable<OrderItem> FindAll(int limit, int offset)
    {
        if (limit == 0 && offset == 0)
        { // 1.if pagination has empty values
            return _dbContext.OrderItems!; // 2.show all produts
        }
        // 3.else show the values of pagination
        return _dbContext.OrderItems!.Skip(offset).Take(limit);

    }

    public OrderItem? findOne(Guid orderId, Guid productId)
    {
        return _dbContext.OrderItems
        .FirstOrDefault(oi => oi.OrderId == orderId && oi.ProductId == productId);
    }

    public OrderItem? findById(Guid orderItemId)
{
    return _dbContext.OrderItems
        .FirstOrDefault(oi => oi.Id == orderItemId);
}

public OrderItem UpdateOne(OrderItem orderItem)
    {
       _dbContext.OrderItems.Update(orderItem);
       _dbContext.SaveChanges();
        return orderItem;
    }

      public async Task<bool> DeleteOneAsync(Guid orderItemId)
    {
        var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);
        if (orderItem == null)
        {
            return false; // Item not found
        }

        _dbContext.OrderItems.Remove(orderItem);
        await _dbContext.SaveChangesAsync();
        return true; // Item successfully deleted
    }

}
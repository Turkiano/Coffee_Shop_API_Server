using AutoMapper;

using Coffee_Shop_App.src.Abstractions;
using Coffee_Shop_App.src.DTOs;
using Coffee_Shop_App.src.Entities;

namespace Coffee_Shop_App.Controllers;

public class OrderService : IOrderService
{
    private IOrderRepository? _orderRepository;

    private IMapper _mapper; //to map DTO file with User entities



    public OrderService(IOrderRepository? orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public OrderReadDto CreateOne(OrderCreateDto order)
    {
        Order? foundOrder = _orderRepository!.findOne((Guid)order.Id); //to avoid duplicated orders

        if (foundOrder is not null)
        {
            return null;
        }
        Order mapperOrder = _mapper.Map<Order>(order);
        Order newOrder = _orderRepository.CreateOne(mapperOrder);
        OrderReadDto orderRead = _mapper.Map<OrderReadDto>(newOrder);
        return orderRead;
    }

    public IEnumerable<OrderReadDto> FindAll()
    {
        var order = _orderRepository!.FindAll();
        var orderRead = order.Select(_mapper.Map<OrderReadDto>);

        return orderRead;
    }

    public OrderReadDto? FindOne(Guid orderId)
    {
        Order? order = _orderRepository!.findOne(orderId);
        OrderReadDto orderRead = _mapper.Map<OrderReadDto>(order);


        return orderRead;
    }
}
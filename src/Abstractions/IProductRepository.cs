
using Coffee_Shop_App.src.DTOs;
using Coffee_Shop_App.src.Entities;

namespace Coffee_Shop_App.src.Abstractions;

public interface IProductRepository
{
    public Product FindOne(Guid productId);

    public IEnumerable<Product> FindAll(int limit, int offset);


    public Product CreateOne(Product product);


    public bool DeleteOne(Product product);


    public Product UpdateOne(Product product);



    }


using Coffee_Shop_App.src.DTOs;
using Coffee_Shop_App.src.Entities;

namespace Coffee_Shop_App.src.Abstractions;

public interface IProductService
{
        public IEnumerable<Product> FindAll();

    // public ProductReadDto FindOne(Guid productId);


    // public Product CreateOne(Product product);

    // public ProductReadDto UpdateOne(Guid Product_Id, ProductCreateDto updatedProduct);




}

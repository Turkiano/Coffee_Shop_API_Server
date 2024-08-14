using Coffee_Shop_API_Server.src.Abstractions;
using Coffee_Shop_App.src.Entities;

namespace Coffee_Shop_App;

class ProductSerice : IProductService
{
    private IProductRepository _ProductRepository; //to talk to the Repo

    public ProductSerice(IProductRepository productRepository)
    {
        _ProductRepository = productRepository;
    }

    public Product CreateOne(Product product)
    {
        throw new NotImplementedException();
    }

    public List<Product> FindAll()
    {
        return _ProductRepository.FindAll();
    }

    public Product FindOne(string productId)
    {
        return _ProductRepository.FindOne(productId);
    }
}
using AutoMapper;

using Coffee_Shop_App.src.DTOs;
using Coffee_Shop_App.src.Abstractions;
using Coffee_Shop_App.src.Entities;

namespace Coffee_Shop_App.src.Services;

class ProductService : IProductService
{
    private IProductRepository _ProductRepository; //to talk to the Repo

    
    public ProductService(IProductRepository productRepository)
    {
        _ProductRepository = productRepository;
    }

    

    public IEnumerable<Product> FindAll()
    {
        return _ProductRepository.FindAll();
    }






    // public ProductReadDto FindOne(Guid productId)
    // {
    //     Product product = _ProductRepository.FindOne(productId);
    //     ProductReadDto productRead = _mapper.Map<ProductReadDto>(product);

    //     Console.WriteLine($"testing ");
        
    //     return productRead ;
    // }

    // public ProductReadDto UpdateOne(Guid Product_Id, ProductCreateDto updatedProduct)
    // {
    //     Product? product = _ProductRepository.FindOne(Product_Id);
    //     if (product is not null) 
    //     {
    //         product.Name = updatedProduct.Product_Name;
    //         Product mappedProduct = _mapper.Map<Product>(product);
    //         Product newProduct =  _ProductRepository.UpdateOne(mappedProduct);
    //         ProductReadDto productRead = _mapper.Map<ProductReadDto>(newProduct);
    //         return productRead;
    //     }
    //     return null;
    // }
}
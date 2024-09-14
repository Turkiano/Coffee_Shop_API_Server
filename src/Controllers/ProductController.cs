
using Coffee_Shop_App.src.Abstractions;
using Coffee_Shop_App.src.Controllers;
using Coffee_Shop_App.src.DTOs;
using Coffee_Shop_App.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Shop_App.src.Controllers;


public class ProductController : BaseController
{

    private IProductService? _productService; //to talk to the service

    public ProductController(IProductService? productService) //this is the constructor
    {
        _productService = productService;
    }






    [HttpPatch("{Product_Id}")]

    public ProductReadDto? UpdateOne(Guid Product_Id, [FromBody] ProductCreateDto updatedProduct)
    {

        return _productService!.UpdateOne(Product_Id, updatedProduct);
    }






    [HttpGet("{productId}")]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    public ProductReadDto? FindOne(Guid productId)
    {


        return _productService!.FindOne(productId);
    }


    [HttpGet]
    public List<ProductReadDto> FindAll()
    {

        return _productService.FindAll();
    }



    [HttpPost] //POST, PUT, or PATCH use fromBody
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Product> CreateOne([FromBody] Product product)
    {
        if (product is not null)
        {

            var newProduct = _productService.CreateOne(product); //sendin request to service
            return CreatedAtAction(nameof(CreateOne), newProduct); //return value in ActionResult

        }
        return BadRequest(); //built-in method for validation
    }

}

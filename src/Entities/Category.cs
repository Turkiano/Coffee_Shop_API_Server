namespace Coffee_Shop_App.src.Entities;

public class Category
{



    public Guid? CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Product>? Products { get; set; }





}
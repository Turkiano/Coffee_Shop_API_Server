using System.ComponentModel.DataAnnotations;
using Coffee_Shop_App.src.Enum;
namespace Coffee_Shop_App.src.Entities;


public class User
{
   
    public Guid? Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
   
    public string? LastName { get; set; }
    [Required]
    public string? Phone { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }

    public string? Salt { get; set; }
    public Role Role { get; set; } = Role.Customer;

    public ICollection<Order>? Orders { get; set; }
    public ICollection<Review>? Reviews { get; set; }









}
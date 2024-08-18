using Coffee_Shop_App.src.Entities;


namespace Coffee_Shop_App.src.Databases;

public class DatabaseContext
{
    public List<User> users; // to store User data as a list
    public List<Product> products;
    public List<Category> categories;
    public List<Order> orders;
    public List<Order_item> orderItems;

    public DatabaseContext() // constructor to add users values
    {
        users = new List<User>
            {
                new User("01", "Khalid", "Hassan", "0594930211", "K.Hassan@gmail.com", "1234456"),
                new User("02", "John", "Guns", "056939830122", "J.Guns@gmail.com", "3452345"),
                new User("03", "Rafah", "Abduallah", "0594930211", "S.A@gmail.com", "463456")
            };

        products = new List<Product>
            {
                new Product("01", DateTime.Now, "Watch X4", "10", "SAR 200", "Watch"),
                new Product("02", DateTime.Now, "Laptop", "16", "SAR 150", "Electronic"),
                new Product("03", DateTime.Now, "Phone", "23", "SAR 1,500", "Electronic"),
                new Product("04", DateTime.Now, "Watch X6", "10", "SAR 250", "Watch")
            };

        categories = new List<Category>
            {
                new Category("01", "Electronic", DateTime.Now),
                new Category("02", "Watches", DateTime.Now)
            };


        orders = new List<Order>
            {
                    new Order("01", "03", "Rafah", "On Progress", 01 ),
                    new Order("02", "01", "Khalid", "On Progress", 02 ),
                    new Order("03", "02", "John", "On Progress", 03 )
            };


        orderItems = new List<Order_item>
        {
            new Order_item("01", "03", 20, DateTime.Now),
            new Order_item("02", "01", 33, DateTime.Now )
        };
    }
}


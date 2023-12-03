using System;
using System.Collections.Generic;

// Клас Товар
class Product : ISearchable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Rating { get; set; }

    public string GetSearchCriteria()
    {
        // Реалізуйте логіку для пошукового критерію, наприклад, за ціною, категорією чи рейтингом
        return $"{Name} - {Category} - {Price}";
    }
}

// Клас Користувач
class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Order> PurchaseHistory { get; set; } = new List<Order>();
}

// Клас Замовлення
class Order
{
    public List<Product> Products { get; set; }
    public List<int> Quantities { get; set; }
    public decimal TotalCost { get; set; }
    public string Status { get; set; }
}

// Інтерфейс для пошуку
interface ISearchable
{
    string GetSearchCriteria();
}

// Клас Магазин
class Store
{
    private List<User> users = new List<User>();
    private List<Product> products = new List<Product>();
    private List<Order> orders = new List<Order>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void PlaceOrder(User user, List<Product> products, List<int> quantities)
    {
        // Логіка оформлення замовлення тут
        // Розрахунок загальної вартості, зміна статусу і т.д.
    }

    public void SearchProducts(ISearchable criteria)
    {
        foreach (var product in products)
        {
            if (product.GetSearchCriteria().Contains(criteria.GetSearchCriteria()))
            {
                Console.WriteLine($"Found product: {product.Name} - {product.Category} - {product.Price}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання класів і методів
        Store myStore = new Store();

        Product laptop = new Product { Name = "Laptop", Price = 1200, Category = "Electronics", Rating = 5 };
        Product phone = new Product { Name = "Phone", Price = 800, Category = "Electronics", Rating = 4 };

        User user1 = new User { Username = "john_doe", Password = "pass123" };

        myStore.AddProduct(laptop);
        myStore.AddProduct(phone);
        myStore.AddUser(user1);

        myStore.SearchProducts(laptop);
    }
}

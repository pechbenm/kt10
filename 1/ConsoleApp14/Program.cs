using System;
using System.Collections.Generic;
using System.Diagnostics;

public interface IEntity
{ 
    int id { get; set; }
}
public interface IRepository<T> where T : IEntity 
{ 
    void Add(T item);
    void Delete(T item);
    T FindById(int id);
    IEnumerable<T> GetAll();

}
public class Product : IEntity
{
    public int id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
public class Customer : IEntity
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
public class ProductRepository : IRepository<Product>
{
    private readonly List<Product> _products = new List<Product>();

    public void Add(Product item)
    {
        _products.Add(item);
    }

    public void Delete(Product item)
    {
        _products.Remove(item);
    }

    public Product FindById(int id)
    {
        return _products.FirstOrDefault(p => p.id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }
}
public class CustomerRepository : IRepository<Customer>
{
    private readonly List<Customer> _customers = new List<Customer>();

    public void Add(Customer item)
    {
        _customers.Add(item);
    }

    public void Delete(Customer item)
    {
        _customers.Remove(item);
    }

    public Customer FindById(int id)
    {
        return _customers.FirstOrDefault(c => c.id == id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customers;
    }
}

public class Program
{
    public static void Main()
    {
        var productRepo = new ProductRepository();

        var product1 = new Product { id = 1, Name = "ноутбук", Price = 1000.00m };
        var product2 = new Product {    id = 2, Name = "телефон", Price = 800.00m };

        productRepo.Add(product1);
        productRepo.Add(product2);

        Console.WriteLine("Все продукты:");
        foreach (var product in productRepo.GetAll())
        {
            Console.WriteLine($"Id: {product.id}, Name: {product.Name}, Price: {product.Price}");
        }

        var foundProduct = productRepo.FindById(1);
        Console.WriteLine($"\nНайден продукт по ID 1: Name: {foundProduct.Name}, Price: {foundProduct.Price}");

        productRepo.Delete(product1);
        Console.WriteLine($"\nПродукт '{product1.Name}' удалён.");

        Console.WriteLine("Оставшиеся продукты:");
        foreach (var product in productRepo.GetAll())
        {
            Console.WriteLine($"Id: {product.id}, Name: {product.Name}, Price: {product.Price}");
        }

        var customerRepo = new CustomerRepository();

        var customer1 = new Customer { id = 1, Name = "Алиса", Address = "краснодар" };
        var customer2 = new Customer { id = 2, Name = "Саша", Address = "москва" };

        customerRepo.Add(customer1);
        customerRepo.Add(customer2);

        Console.WriteLine("\nВсе клиенты:");
        foreach (var customer in customerRepo.GetAll())
        {
            Console.WriteLine($"Id: {customer.id}, Name: {customer.Name}, Address: {customer.Address}");
        }

        var foundCustomer = customerRepo.FindById(2);
        Console.WriteLine($"\nНайден клиент по ID 2: Name: {foundCustomer.Name}, Address: {foundCustomer.Address}");

        customerRepo.Delete(customer1);
        Console.WriteLine($"\nКлиент '{customer1.Name}' удалён.");

        Console.WriteLine("Оставшиеся клиенты:");
        foreach (var customer in customerRepo.GetAll())
        {
            Console.WriteLine($"Id: {customer.id}, Name: {customer.Name}, Address: {customer.Address}");
        }

    }
}


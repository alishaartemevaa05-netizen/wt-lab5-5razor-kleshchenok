using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Data;

public static class CustomerStore
{
    private static readonly object _lock = new();
    private static int _nextId = 4;

    public static List<Customer> Customers { get; } = new()
    {
        new Customer { Id = 1, FullName = "Иванов Иван Иванович",
                       Phone = "+375291112233", Email = "ivanov@mail.ru",
                       DriverLicense = "AB123456" },
        new Customer { Id = 2, FullName = "Петрова Анна Сергеевна",
                       Phone = "+375292223344", Email = "petrova@mail.ru",
                       DriverLicense = "CD789012" },
        new Customer { Id = 3, FullName = "Сидоров Пётр Алексеевич",
                       Phone = "+375293334455", Email = null,
                       DriverLicense = "EF345678" }
    };

    public static List<Customer> GetAll() { lock (_lock) { return Customers.ToList(); } }

    public static Customer? GetById(int id)
    {
        lock (_lock) { return Customers.FirstOrDefault(c => c.Id == id); }
    }

    public static void Add(Customer customer)
    {
        lock (_lock)
        {
            customer.Id = _nextId++;
            Customers.Add(customer);
        }
    }
}
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Data;

public static class RentalStore
{
    private static readonly object _lock = new();
    private static int _nextId = 3;

    public static List<Rental> Rentals { get; } = new()
    {
        new Rental { Id = 1, CarId = 1, CustomerId = 1,
                     StartDate = DateTime.Today.AddDays(-10),
                     EndDate = DateTime.Today.AddDays(-5),
                     TotalPrice = 300, Status = RentalStatus.Completed },
        new Rental { Id = 2, CarId = 2, CustomerId = 2,
                     StartDate = DateTime.Today.AddDays(-2),
                     EndDate = DateTime.Today.AddDays(3),
                     TotalPrice = 450, Status = RentalStatus.Active }
    };

    public static List<Rental> GetAll() { lock (_lock) { return Rentals.ToList(); } }

    public static Rental? GetById(int id)
    {
        lock (_lock) { return Rentals.FirstOrDefault(r => r.Id == id); }
    }

    public static void Add(Rental rental)
    {
        lock (_lock)
        {
            rental.Id = _nextId++;
            Rentals.Add(rental);
        }
    }

    public static void Complete(int id)
    {
        lock (_lock)
        {
            var rental = Rentals.FirstOrDefault(r => r.Id == id);
            if (rental != null) rental.Status = RentalStatus.Completed;
        }
    }
}
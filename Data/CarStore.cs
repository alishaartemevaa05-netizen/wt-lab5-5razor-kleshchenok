using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Data;

public static class CarStore
{
    private static readonly object _lock = new();
    private static int _nextId = 7;

    public static List<Car> Cars { get; } = new()
    {
        new Car { Id = 1, Brand = "Hyundai", Model = "Solaris", Year = 2023,
                  Category = CarCategory.Economy, Transmission = Transmission.Automatic,
                  FuelType = FuelType.Petrol, Seats = 5, DailyPrice = 60,
                  IsAvailable = true, Description = "Экономичный городской автомобиль" },
        new Car { Id = 2, Brand = "Kia", Model = "Sportage", Year = 2022,
                  Category = CarCategory.Suv, Transmission = Transmission.Automatic,
                  FuelType = FuelType.Diesel, Seats = 5, DailyPrice = 90,
                  IsAvailable = false, Description = "Просторный кроссовер" },
        new Car { Id = 3, Brand = "BMW", Model = "5 Series", Year = 2024,
                  Category = CarCategory.Business, Transmission = Transmission.Automatic,
                  FuelType = FuelType.Petrol, Seats = 5, DailyPrice = 180,
                  IsAvailable = true, Description = "Бизнес-седан премиум-класса" },
        new Car { Id = 4, Brand = "Tesla", Model = "Model 3", Year = 2024,
                  Category = CarCategory.Comfort, Transmission = Transmission.Automatic,
                  FuelType = FuelType.Electric, Seats = 5, DailyPrice = 150,
                  IsAvailable = true, Description = "Электромобиль, запас хода 500 км" },
        new Car { Id = 5, Brand = "Volkswagen", Model = "Multivan", Year = 2021,
                  Category = CarCategory.Minivan, Transmission = Transmission.Automatic,
                  FuelType = FuelType.Diesel, Seats = 7, DailyPrice = 120,
                  IsAvailable = true, Description = "Семейный минивэн на 7 мест" },
        new Car { Id = 6, Brand = "Toyota", Model = "Camry", Year = 2023,
                  Category = CarCategory.Comfort, Transmission = Transmission.Automatic,
                  FuelType = FuelType.Hybrid, Seats = 5, DailyPrice = 100,
                  IsAvailable = true, Description = "Надёжный гибридный седан" }
    };

    public static List<Car> GetAll()
    {
        lock (_lock) { return Cars.ToList(); }
    }

    public static Car? GetById(int id)
    {
        lock (_lock) { return Cars.FirstOrDefault(c => c.Id == id); }
    }

    public static void Add(Car car)
    {
        lock (_lock)
        {
            car.Id = _nextId++;
            Cars.Add(car);
        }
    }

    public static bool Remove(int id)
    {
        lock (_lock)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return false;
            Cars.Remove(car);
            return true;
        }
    }
}
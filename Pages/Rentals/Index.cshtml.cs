using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Rentals;

public class IndexModel : PageModel
{
    public List<RentalListItem> Rentals { get; set; } = new();

    public void OnGet()
    {
        var cars = CarStore.GetAll().ToDictionary(c => c.Id);
        var customers = CustomerStore.GetAll().ToDictionary(c => c.Id);

        Rentals = RentalStore.GetAll().Select(r => new RentalListItem
        {
            RentalId = r.Id,
            CarName = cars.TryGetValue(r.CarId, out var car) ? car.FullName : "—",
            CustomerName = customers.TryGetValue(r.CustomerId, out var c) ? c.FullName : "—",
            StartDate = r.StartDate,
            EndDate = r.EndDate,
            TotalPrice = r.TotalPrice,
            Status = r.Status
        }).ToList();
    }

    public IActionResult OnPostReturn(int id)
    {
        var rental = RentalStore.GetById(id);
        if (rental == null) return NotFound();

        RentalStore.Complete(id);
        var car = CarStore.GetById(rental.CarId);
        if (car != null) car.IsAvailable = true;

        TempData["Message"] = "Аренда завершена, автомобиль доступен.";
        return RedirectToPage("./Index");
    }
}
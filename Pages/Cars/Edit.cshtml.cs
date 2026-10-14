using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Cars;

public class EditModel : PageModel
{
    [BindProperty]
    public Car Car { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var car = CarStore.GetById(id);
        if (car == null) return NotFound();
        Car = car;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var existing = CarStore.GetById(Car.Id);
        if (existing == null) return NotFound();

        existing.Brand = Car.Brand;
        existing.Model = Car.Model;
        existing.Year = Car.Year;
        existing.Category = Car.Category;
        existing.Transmission = Car.Transmission;
        existing.FuelType = Car.FuelType;
        existing.Seats = Car.Seats;
        existing.DailyPrice = Car.DailyPrice;
        existing.IsAvailable = Car.IsAvailable;
        existing.Description = Car.Description;

        TempData["Message"] = $"Автомобиль «{existing.FullName}» обновлён.";
        return RedirectToPage("./Details", new { id = existing.Id });
    }
}
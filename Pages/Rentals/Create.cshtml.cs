using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Rentals;

public class CreateModel : PageModel
{
    [BindProperty]
    public Rental Rental { get; set; } = new();

    public SelectList AvailableCars { get; set; } = null!;
    public SelectList Customers { get; set; } = null!;

    public void OnGet()
    {
        LoadLists();
    }

    public IActionResult OnPost()
    {
        LoadLists();

        if (Rental.EndDate <= Rental.StartDate)
        {
            ModelState.AddModelError("Rental.EndDate",
                "Дата окончания должна быть позже даты начала.");
        }

        var car = CarStore.GetById(Rental.CarId);
        if (car == null || !car.IsAvailable)
        {
            ModelState.AddModelError("Rental.CarId",
                "Выбранный автомобиль недоступен.");
        }

        if (!ModelState.IsValid) return Page();

        var days = (Rental.EndDate - Rental.StartDate).Days;
        Rental.TotalPrice = days * car!.DailyPrice;
        Rental.Status = RentalStatus.Active;

        RentalStore.Add(Rental);
        car.IsAvailable = false;

        TempData["Message"] = $"Аренда оформлена. Стоимость: {Rental.TotalPrice:0.##} руб.";
        return RedirectToPage("./Index");
    }

    private void LoadLists()
    {
        AvailableCars = new SelectList(
            CarStore.GetAll().Where(c => c.IsAvailable),
            "Id", "FullName");

        Customers = new SelectList(
            CustomerStore.GetAll(),
            "Id", "FullName");
    }
}
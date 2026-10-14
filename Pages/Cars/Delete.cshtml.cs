using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Cars;

public class DeleteModel : PageModel
{
    public Car? Car { get; set; }

    public IActionResult OnGet(int id)
    {
        Car = CarStore.GetById(id);
        if (Car == null) return NotFound();
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        var activeRental = RentalStore.GetAll()
            .Any(r => r.CarId == id && r.Status == RentalStatus.Active);
        if (activeRental)
        {
            TempData["Message"] = "Нельзя удалить автомобиль в активной аренде.";
            return RedirectToPage("./Index");
        }

        CarStore.Remove(id);
        TempData["Message"] = "Автомобиль удалён.";
        return RedirectToPage("./Index");
    }
}
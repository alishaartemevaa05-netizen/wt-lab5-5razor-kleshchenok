using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Cars;

public class CreateModel : PageModel
{
    [BindProperty]
    public Car Car { get; set; } = new();

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        CarStore.Add(Car);
        TempData["Message"] = $"Автомобиль «{Car.FullName}» добавлен.";
        return RedirectToPage("./Index");
    }
}
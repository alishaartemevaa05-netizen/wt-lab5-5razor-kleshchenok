using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Cars;

public class DetailsModel : PageModel
{
    public Car? Car { get; set; }

    public IActionResult OnGet(int id)
    {
        Car = CarStore.GetById(id);
        if (Car == null) return NotFound();
        return Page();
    }
}
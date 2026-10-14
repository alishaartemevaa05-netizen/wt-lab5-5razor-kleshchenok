using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Cars;

public class IndexModel : PageModel
{
    public List<Car> Cars { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public CarCategory? Category { get; set; }

    public void OnGet()
    {
        var query = CarStore.GetAll().AsEnumerable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(c =>
                c.Brand.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
                c.Model.Contains(Search, StringComparison.OrdinalIgnoreCase));
        }

        if (Category.HasValue)
            query = query.Where(c => c.Category == Category.Value);

        Cars = query.OrderBy(c => c.Id).ToList();
    }
}
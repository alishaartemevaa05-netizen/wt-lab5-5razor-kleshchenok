using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages;

public class IndexModel : PageModel
{
    public int TotalCars { get; set; }
    public int AvailableCars { get; set; }
    public int TotalCustomers { get; set; }
    public int ActiveRentals { get; set; }

    public void OnGet()
    {
        TotalCars = CarStore.GetAll().Count;
        AvailableCars = CarStore.GetAll().Count(c => c.IsAvailable);
        TotalCustomers = CustomerStore.GetAll().Count;
        ActiveRentals = RentalStore.GetAll().Count(r => r.Status == RentalStatus.Active);
    }
}
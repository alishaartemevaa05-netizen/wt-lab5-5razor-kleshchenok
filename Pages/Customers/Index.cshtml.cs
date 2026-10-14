using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_kleshchenok.Data;
using wt_lab5_5razor_kleshchenok.Models;

namespace wt_lab5_5razor_kleshchenok.Pages.Customers;

public class IndexModel : PageModel
{
    public List<Customer> Customers { get; set; } = new();

    public void OnGet() { Customers = CustomerStore.GetAll(); }
}
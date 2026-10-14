namespace wt_lab5_5razor_kleshchenok.Models;

public class RentalListItem
{
    public int RentalId { get; set; }
    public string CarName { get; set; } = "";
    public string CustomerName { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public RentalStatus Status { get; set; }
}
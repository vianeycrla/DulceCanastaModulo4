namespace DulceCanastaModulo4.ViewModels;

public class CarritoViewModel
{
    public List<SessionCartItemViewModel> Items { get; set; } = new();
    public decimal Total => Items.Sum(x => x.Subtotal);
}

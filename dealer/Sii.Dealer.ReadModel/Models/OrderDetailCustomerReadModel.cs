namespace Sii.Dealer.ReadModel.Models;

public class OrderDetailCustomerReadModel
{
    public OrderDetailCustomerReadModel(string customerFirstName, string customerLastName, string customerEmail, string customerPhone)
    {
        CustomerFirstName = customerFirstName;
        CustomerLastName = customerLastName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
    }

    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
}

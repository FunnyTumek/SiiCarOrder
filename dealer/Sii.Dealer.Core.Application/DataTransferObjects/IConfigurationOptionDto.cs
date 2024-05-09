
namespace Sii.Dealer.Core.Application.DataTransferObjects
{
    public  interface IConfigurationOptionDto
    {   
        string Code { get; set; }

        string Name { get; set; }

        bool Availability { get; set; }

        decimal Price { get; set; }
    }
}

using Sii.Dealer.SharedKernel.Sales.ViewModels;
using System.IO;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.Infrastructure
{
    public interface IPdfService
    {
        Task GeneratePdf(Stream stream, PdfDetailViewModel pdfDetailViewModel);
        Task<PdfDetailViewModel> GetPdfDetail(int id);

	}
}

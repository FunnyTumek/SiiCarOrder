using MediatR;
using Sii.Dealer.Core.Application.Services.Infrastructure;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Commands
{
    public class GenerateInvoiceCommand : IRequest<byte[]>
    {
        public int Id { get; set; }
    }

    public class GenerateInvoiceCommandHandler : IRequestHandler<GenerateInvoiceCommand, byte[]>
    {
        private readonly IPdfService _pdfService;
        public GenerateInvoiceCommandHandler(IPdfService pdfService)
        {
			_pdfService = pdfService;
        }
        public async Task<byte[]> Handle(GenerateInvoiceCommand request, CancellationToken cancellationToken)
        {
			using (var stream = new MemoryStream())
			{
				var order = await _pdfService.GetPdfDetail(request.Id);
				await _pdfService.GeneratePdf(stream, order);
				stream.Seek(0, SeekOrigin.Begin);

                byte[] bytes;
                bytes= stream.ToArray();

                return bytes;
			}
        }
    }
}
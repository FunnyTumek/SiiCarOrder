using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Sii.Dealer.Core.Application.Services.Infrastructure;
using Sii.Dealer.Core.Infrastructure.Data;
using Sii.Dealer.SharedKernel.Enums;
using Sii.Dealer.SharedKernel.Sales.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Services.Infrastructure
{
	public class PdfService : IPdfService
	{
		private readonly ILogger<PdfService> logger;
		private readonly SalesDbContext context;

		public PdfService(ILogger<PdfService> logger, SalesDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public async Task<PdfDetailViewModel> GetPdfDetail(int id)
		{
			var pdfDetailViewModel = await this.context.PdfDetailViewModel.FirstOrDefaultAsync(x => x.id == id);
			if (pdfDetailViewModel == null) throw new Exception("There is no such ID.");
			return pdfDetailViewModel;
		}

		public async Task GeneratePdf(Stream stream, PdfDetailViewModel pdfDetailViewModel)
		{
			var document = Document.Create(container =>
			{
				container.Page(page =>
				{
					page.Size(PageSizes.A4);
					page.Margin(2, Unit.Centimetre);
					page.PageColor(Colors.White);
					page.DefaultTextStyle(x => x.FontSize(14));

					page.Header()
						.Height(40)
						.AlignCenter()
						.Background(Colors.Grey.Lighten1)
						.AlignMiddle()
						.Text($"Agreement {pdfDetailViewModel.id}")
						.SemiBold().FontSize(19)
						.FontColor(Colors.Black);

					page.Content()
						.PaddingVertical(1, Unit.Centimetre)
						.Column(x =>
						{
							x.Spacing(10);
							x.Item().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Medium);
							x.Item().Text($"Customer:\nName: {pdfDetailViewModel.CustomerFirstName} {pdfDetailViewModel.CustomerLastName}\nEmail:{pdfDetailViewModel.CustomerEmail}\nPhone:{pdfDetailViewModel.CustomerPhone}");
							x.Item().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Medium);

							x.Item().Text($"Information:\nId: {pdfDetailViewModel.id} \nCreation date:{pdfDetailViewModel.CreationDate}\nAgreement signed date: {pdfDetailViewModel.AgreementSignedDate}\nPrice: {pdfDetailViewModel.Price}\nDiscount: {pdfDetailViewModel.Discount}\nStatus: {pdfDetailViewModel.Status}\nCar Vin: {pdfDetailViewModel.CarVin}");
							x.Item().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Medium);

							x.Item().Text($"Configuration:\nBrand: {pdfDetailViewModel.Brand} \nClass: {pdfDetailViewModel.Class}\nModel: {pdfDetailViewModel.Model}\nColor: {pdfDetailViewModel.Color}\nEngine: {pdfDetailViewModel.Engine}\nType: {Enum.GetName(typeof(EngineType), pdfDetailViewModel.EngineType)}\nCapacity: {pdfDetailViewModel.EngineCapacity}\nPower: {pdfDetailViewModel.EnginePower}\nEquipmentVersion: {pdfDetailViewModel.EquipmentVersion}\nGearbox Type: {Enum.GetName(typeof(GearboxType), pdfDetailViewModel.GearboxType)}\nGearbox count: {pdfDetailViewModel.GearboxCount}\nInterior: {pdfDetailViewModel.Interior}");
						});

					page.Footer()
						.AlignCenter()
						.Text(x =>
						{
							x.Span("Page ");
							x.CurrentPageNumber();
						});
				});
			});
			logger.LogInformation("Pdf has been generated.");
			document.GeneratePdf(stream);
		}
	}
}

using Configurator.Api.Dtos.Contracts;
using FluentValidation;

namespace Configurator.Api.Validators;

public class ConfigurationValidator : AbstractValidator<CarConfigurationBaseDto>
{
	public ConfigurationValidator()
	{
		RuleFor(c => c.Brand).NotEmpty();
		RuleFor(c => c.Model).NotEmpty();
		RuleFor(c => c.EquipmentVersion).NotEmpty();
		RuleFor(c => c.Class).NotEmpty();
		RuleFor(c => c.Color).NotEmpty();
		RuleFor(c => c.Interior).NotEmpty();
		RuleFor(c => c.Engine).NotEmpty();
		When(c => c.Engine is not null, () =>
		{
			RuleFor(c => c.Engine!.Type).NotEmpty();
			RuleFor(c => c.Engine!.Power).NotEmpty().GreaterThan(0);
		});
		RuleFor(c => c.Gearbox).NotEmpty();
		When(c => c.Gearbox is not null, () =>
		{
			RuleFor(c => c.Gearbox!.Type).NotEmpty();
			RuleFor(c => c.Gearbox!.GearsCount).NotEmpty().GreaterThan(0);
		});
		When(c => c.AdditionalEquipments is not null, () =>
		{
			RuleForEach(c => c.AdditionalEquipments).NotEmpty();
		});
	}
}

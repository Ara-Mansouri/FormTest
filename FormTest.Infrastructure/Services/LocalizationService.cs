using FormTest.Core.Application.Contracts;
using Microsoft.Extensions.Localization;
using FormTest.Localization.Resources;
namespace FormTest.Infrastructure.Services
{
    public class LocalizationService : ILocalizationService
    {
        public readonly IStringLocalizer<SharedResource> _Localizer;
        public LocalizationService(IStringLocalizer<SharedResource> localizer)
        {
            _Localizer = localizer;
        }

        public string this[string key] => _Localizer[key];
    }
}

using FormTest.Core.Application.Contracts;
using System.Globalization;
using System.Resources;
using FormTest.Localization.Resources;

namespace FormTest.Infrastructure.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _resourceManager =
            new("FormTest.Localization.Resources.SharedResource", typeof(SharedResource).Assembly);

        public string this[string key] =>
            _resourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? key;
    }
}

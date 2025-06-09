using System.Globalization;
using System.Resources;


namespace FormTest.Localization.Resources
{
    /// <summary>
    /// Provides strongly typed access to resource strings for validation messages.
    /// </summary>
    public class SharedResource
    {
        private static readonly ResourceManager _resourceManager = new(
            "FormTest.Localization.Resources.SharedResource",
            typeof(SharedResource).Assembly);

        private static CultureInfo? _resourceCulture;

        /// <summary>
        /// Gets or sets the culture for resource lookups.
        /// </summary>
        public static CultureInfo? Culture
        {
            get => _resourceCulture;
            set => _resourceCulture = value;
        }

        private static string GetString(string name)
            => _resourceManager.GetString(name, _resourceCulture) ?? string.Empty;

        public static string EmailAlreadyRegistered => GetString(nameof(EmailAlreadyRegistered));
        public static string UserNotFound => GetString(nameof(UserNotFound));
        public static string UserNotApproved => GetString(nameof(UserNotApproved));
        public static string NameRequired => GetString(nameof(NameRequired));
        public static string EmailRequired => GetString(nameof(EmailRequired));
        public static string InvalidEmail => GetString(nameof(InvalidEmail));
        public static string PasswordRequired => GetString(nameof(PasswordRequired));
        public static string PasswordMinLength => GetString(nameof(PasswordMinLength));
        public static string WelcomeUser => GetString(nameof(WelcomeUser));
    }
}
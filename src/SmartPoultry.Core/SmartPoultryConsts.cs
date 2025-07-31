using SmartPoultry.Debugging;

namespace SmartPoultry
{
    public class SmartPoultryConsts
    {
        public const string LocalizationSourceName = "SmartPoultry";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "b205124563f34a4199a826a5af164a59";
    }
}

using SmartPoultry.Debugging;

namespace SmartPoultry;

public class SmartPoultryConsts
{
    public const string LocalizationSourceName = "SmartPoultry";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "76e13f73973041f4a5165de93add65bf";
}

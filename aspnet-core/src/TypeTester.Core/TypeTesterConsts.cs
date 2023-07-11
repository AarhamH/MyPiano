using TypeTester.Debugging;

namespace TypeTester
{
    public class TypeTesterConsts
    {
        public const string LocalizationSourceName = "TypeTester";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ebceb5eb6a5d4adda45441820e68ad32";
    }
}

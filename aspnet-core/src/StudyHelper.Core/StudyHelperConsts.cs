using StudyHelper.Debugging;

namespace StudyHelper
{
    public class StudyHelperConsts
    {
        public const string LocalizationSourceName = "StudyHelper";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c29f8a5b36b247b88dded14484382c0a";
    }
}

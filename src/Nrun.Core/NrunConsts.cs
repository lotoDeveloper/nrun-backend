using Nrun.Debugging;

namespace Nrun
{
    public class NrunConsts
    {
        public const string LocalizationSourceName = "Nrun";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "86218fb9c50648b886f031e947e76846";
    }
}

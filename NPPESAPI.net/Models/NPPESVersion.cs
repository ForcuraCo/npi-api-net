namespace Forcura.NPPES.Models
{
    /// <summary>
    /// Versions of the NPPES API
    /// </summary>
    public enum NPPESVersion
    {
        /// <summary>
        /// Version 2.1
        /// </summary>
        v2_1,
    }

    internal static class VersionExtension
    {
        public static string ToVersionString(this NPPESVersion version)
        {
            switch (version)
            {
                case NPPESVersion.v2_1:
                    return "2.1";
                default:
                    return "2.1";
            }
        }
    }
}

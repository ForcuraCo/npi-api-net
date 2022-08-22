using System;

namespace Forcura.NPPES.Models
{
    /// <summary>
    /// Versions of the NPPES API
    /// </summary>
    public enum NPPESVersion
    {
        /// <summary>
        /// Version 1.0
        /// </summary>
        [Obsolete("API Versions 1.0 and 2.0 are NOW retired, please switch your application to use API Version 2.1 if you have not already done so. The old links https://npiregistry.cms.hhs.gov/api?version=1.0 , https://npiregistry.cms.hhs.gov/api?version=2.0 , and https://npiregistry.cms.hhs.gov/api (without the version flag) will no longer work. Please contact NPIFiles@cms.hhs.gov if you have further questions.")]
        v1_0,
        /// <summary>
        /// Version 2.0
        /// </summary>
        [Obsolete("API Versions 1.0 and 2.0 are NOW retired, please switch your application to use API Version 2.1 if you have not already done so. The old links https://npiregistry.cms.hhs.gov/api?version=1.0 , https://npiregistry.cms.hhs.gov/api?version=2.0 , and https://npiregistry.cms.hhs.gov/api (without the version flag) will no longer work. Please contact NPIFiles@cms.hhs.gov if you have further questions.")]
        v2_0,
        /// <summary>
        /// Version 2.1
        /// </summary>
        v2_1,
    }

    internal static class VersionExtension
    {
        public static string ToVersionString(this NPPESVersion version)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            // we are alerting the consumer to this deprecation
            // we'll look to remove completely in the next version
            switch (version)
            {
                case NPPESVersion.v1_0:
                    return "1.0";
                case NPPESVersion.v2_0:
                    return "2.0";
                case NPPESVersion.v2_1:
                    return "2.1";
                default:
                    return "2.1";
            }
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}

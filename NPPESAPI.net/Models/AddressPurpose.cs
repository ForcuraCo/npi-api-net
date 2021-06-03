namespace Forcura.NPPES.Models
{
    /// <summary>
    /// Refers to whether the address information entered pertains to the provider's Mailing Address or the provider's Practice Location Address. 
    /// When not specified, the results will contain the providers where either the Mailing Address or any of Practice Location Addresses match the 
    /// entered address information. PRIMARY will only search against Primary Location Address. While Secondary will only search against Secondary 
    /// Location Addresses.
    /// </summary>
    public enum AddressPurpose
    {
        /// <summary>
        /// Location.
        /// </summary>
        Location,

        /// <summary>
        /// Mailing address.
        /// </summary>
        Mailing,

        /// <summary>
        /// Primary address.
        /// </summary>
        Primary,

        /// <summary>
        /// Secondary address.
        /// </summary>
        Secondary
    }
}

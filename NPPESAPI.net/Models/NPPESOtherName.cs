namespace Forcura.NPPES.Models
{
    /// <summary>
    /// Other names associated to the NPI.
    /// </summary>
    public class NPPESOtherName
    {
        /// <summary>
        /// The organization name.
        /// </summary>
        public string OrganizationName { get; set; }

/// <summary>
/// The code.
/// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The name prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// The name suffix.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// The credentials.
        /// </summary>
        public string Credential { get; set; }
    }
}

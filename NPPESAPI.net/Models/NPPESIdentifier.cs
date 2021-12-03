namespace Forcura.NPPES.Models
{
    /// <summary>
    /// Describes an identifier of the NPI entry.
    /// </summary>
    public class NPPESIdentifier
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; set; }
    }
}

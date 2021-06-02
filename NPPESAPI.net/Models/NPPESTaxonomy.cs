namespace Forcura.NPPES.Models
{
    /// <summary>
    /// The taxonomy type set for identifying the provider type and area of specialization for health care providers.
    /// </summary>
    public class NPPESTaxonomy
    {
        /// <summary>
        /// The taxonomy code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The taxonomy description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The taxonomy license.
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// Identifies if this is the primary taxonomy.
        /// </summary>
        public bool Primary { get; set; }

        /// <summary>
        /// The state.
        /// </summary>
        public string State { get; set; }
    }
}

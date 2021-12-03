using System;
using System.Collections.Generic;

namespace Forcura.NPPES.Models
{
    /// <summary>
    /// A search result returned from the NPPES API.
    /// </summary>
    public class NPPESResult
    {
        /// <summary>
        /// The registered NPI number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Basic information regarding the search result.
        /// </summary>
        public NPPESBasic Basic { get; set; }

        /// <summary>
        /// The last time the record was updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The time the record was created and registered in the NPPES registry.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Enumeration type identifying whether this record represents an Individual or an Organization.
        /// </summary>
        public NPPESType EnumerationType { get; set; }

        /// <summary>
        /// The registered addresses.
        /// </summary>
        public IList<NPPESAddress> Addresses { get; set; }

        /// <summary>
        /// Other identifiers.
        /// </summary>
        public IList<NPPESIdentifier> Identifiers { get; set; }

        /// <summary>
        /// Other names.
        /// </summary>
        public IList<NPPESOtherName> OtherNames { get; set; }

        /// <summary>
        /// Taxonomies.
        /// </summary>
        public IList<NPPESTaxonomy> Taxonomies { get; set; }
    }
}

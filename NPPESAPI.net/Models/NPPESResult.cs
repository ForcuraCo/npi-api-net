using System;
using System.Collections.Generic;

namespace Forcura.NPPES.Models
{
    public class NPPESResult
    {
        public string Number { get; set; }
        public NPPESBasic Basic { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Created { get; set; }
        public NPPESType EnumerationType { get; set; }
        public IList<NPPESAddress> Addresses { get; set; }
        public IList<NPPESIdentifier> Identifiers { get; set; }
        public IList<NPPESOtherName> OtherNames { get; set; }
        public IList<NPPESTaxonomy> Taxonomies { get; set; }
    }
}

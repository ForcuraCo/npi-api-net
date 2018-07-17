using System;

namespace Forcura.NPPES.Models
{
    public class NPPESBasic
    {
        public string ReplacementNPI { get; set; }
        public string EIN { get; set; }
        public string OrganizationName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public string Credential { get; set; }
        public string Gender { get; set; }
        public DateTime EnumerationDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

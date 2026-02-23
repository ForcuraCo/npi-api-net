using System;

namespace Forcura.NPPES.Models
{
    /// <summary>
    /// Basic information regarding the NPPES entry.
    /// </summary>
    public class NPPESBasic
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReplacementNPI { get; set; }

        /// <summary>
        /// EIN number on file if this is an organization.
        /// </summary>
        public string EIN { get; set; }

        /// <summary>
        /// Organization name.
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Parent Organization Legal Business Name
        /// </summary>
        public string ParentOrganizationLegalBusinessName { get; set; }

        /// <summary>
        /// The registered individual's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The registered individual's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The registered individual's middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The registered individual's name prefix (Dr., Sr., Ms. etc).
        /// </summary>
        public string NamePrefix { get; set; }

        /// <summary>
        /// The registered individual's name suffix (Jr., Sr. etc).
        /// </summary>
        public string NameSuffix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Credential { get; set; }

        /// <summary>
        /// The registered Individual's gender.
        /// </summary>
        public string Gender { get; set; }
        
        /// <summary>
        /// The registered Individual's sex.
        /// </summary>
        public string Sex { get; set; }
        
        /// <summary>
        /// The time the record was created.
        /// </summary>
        public DateTime EnumerationDate { get; set; }

        /// <summary>
        /// The time the information was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}

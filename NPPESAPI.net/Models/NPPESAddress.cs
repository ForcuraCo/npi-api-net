namespace Forcura.NPPES.Models
{
    public class NPPESAddress
    {
        /// <summary>
        /// Address line 1.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address line 2.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Purpose of address (Mailing, Primary, Secondary, etc.).
        /// </summary>
        public AddressPurpose AddressPurpose { get; set; }

        /// <summary>
        /// Address type (DOM, FGN, MIL).
        /// </summary>
        public AddressType AddressType { get; set; }

        /// <summary>
        /// The city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// The postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The state abbreviation.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The telephone number.
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// The fax number.
        /// </summary>
        public string FaxNumber { get; set; }
    }
}

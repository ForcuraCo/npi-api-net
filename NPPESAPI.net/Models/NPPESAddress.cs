namespace Forcura.NPPES.Models
{
    public class NPPESAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public AddressPurpose AddressPurpose { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string TelephoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}

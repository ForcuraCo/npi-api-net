using Forcura.NPPES.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Forcura.NPPES
{
    public class NPPESRequest
    {
        /// <summary>
        /// The NPI Number is the unique 10-digit National Provider Identifier assigned to the provider.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The Read API can be refined to retrieve only Individual Providers or Organizational Providers. When it is not specified, both Type 1 and Type 2 NPIs will be returned. When using the Enumeration Type, it cannot be the only criteria entered. Additional criteria must also be entered as well.
        /// </summary>
        public NPPESType? EnumerationType { get; set; }

        /// <summary>
        /// Search for providers by their taxonomy by entering the taxonomy description.
        /// </summary>
        public string TaxonomyDescription { get; set; }

        /// <summary>
        /// This field only applies to Individual Providers. Trailing wildcard entries are permitted requiring at least two characters to be entered (e.g. "jo*" ). This field allows the following special characters: ampersand, apostrophe, colon, comma, forward slash, hyphen, left and right parentheses, period, pound sign, quotation mark, and semi-colon.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// This field only applies to Individual Providers. Trailing wildcard entries are permitted requiring at least two characters to be entered. This field allows the following special characters: ampersand, apostrophe, colon, comma, forward slash, hyphen, left and right parentheses, period, pound sign, quotation mark, and semi-colon.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// This field only applies to Organizational Providers. Trailing wildcard entries are permitted requiring at least two characters to be entered. This field allows the following special characters: ampersand, apostrophe, "at" sign, colon, comma, forward slash, hyphen, left and right parentheses, period, pound sign, quotation mark, and semi-colon. All types of Organization Names (LBN, DBA, Former LBN, Other Name) associated with an NPI are examined for matching contents, therefore, the results might contain an organization name different from the one entered in the Organization Name criterion.
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Refers to whether the address information entered pertains to the provider's Mailing Address or the provider's Practice Location Address. When not specified, the results will contain the providers where either the Mailing Address or any of Practice Location Addresses match the entered address information. PRIMARY will only search against Primary Location Address. While Secondary will only search against Secondary Location Addresses.
        /// </summary>
        public AddressPurpose? AddressPurpose { get; set; }

        /// <summary>
        /// The City associated with the provider's address identified in Address Purpose. To search for a Military Address enter either APO or FPO into the City field. This field allows the following special characters: ampersand, apostrophe, colon, comma, forward slash, hyphen, left and right parentheses, period, pound sign, quotation mark, and semi-colon.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The State abbreviation associated with the provider's address identified in Address Purpose. This field cannot be used as the only input criterion. If this field is used, at least one other field, besides the Enumeration Type and Country, must be populated. See https://npiregistry.cms.hhs.gov/registry/API-State-Abbr for valid values for states.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The Postal Code associated with the provider's address identified in Address Purpose. There is an implied trailing wildcard. If you enter a 5 digit postal code, it will match any appropriate 9 digit (zip+4) codes in the data.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The Country associated with the provider's address identified in Address Purpose. This field can be used as the only input criterion as long as the value selected is not US (United States). See https://npiregistry.cms.hhs.gov/registry/API-Country-Abbr for valid values for countries.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Limit the results returned. The default value is 10; however, the value can be set to any value from 1 to 200.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The first N (value entered) results meeting the entered criteria will be bypassed and will not be included in the output.
        /// </summary>
        public int? Skip { get; set; }

        internal string ToQuery()
        {
            var query = new Dictionary<string, string>();

            AddStringParam(query, "number", Number);
            AddStringParam(query, "taxonomy_description", TaxonomyDescription);
            AddStringParam(query, "first_name", FirstName);
            AddStringParam(query, "last_name", LastName);
            AddStringParam(query, "organization_name", OrganizationName);
            AddStringParam(query, "address_purpose", AddressPurpose?.ToString()?.ToUpper());
            AddStringParam(query, "city", City);
            AddStringParam(query, "state", State);
            AddStringParam(query, "postal_code", PostalCode);
            AddStringParam(query, "country_code", CountryCode);

            if (EnumerationType.HasValue)
                query.Add("enumeration_type", EnumerationType == NPPESType.NPI1 ? "NPI-1" : "NPI-2");

            if (Limit.HasValue)
                query.Add("limit", Limit.ToString());

            if (Skip.HasValue)
                query.Add("skip", Skip.ToString());

            return "?" + string.Join("&", query.Select(i => $"{i.Key}={WebUtility.UrlEncode(i.Value)}"));
        }

        private void AddStringParam(IDictionary<string, string> parameters, string paramName, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                parameters.Add(paramName, value);
        }
    }
}

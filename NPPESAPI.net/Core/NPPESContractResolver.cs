using Forcura.NPPES.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Forcura.NPPES.Core
{
    internal class NPPESContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            ChangePropertyName(member.DeclaringType, property);

            return property;
        }

        private static void ChangePropertyName(Type type, JsonProperty property)
        {
            if (typePropertyLookup.TryGetValue(type, out Dictionary<string, string> propertyNameLookup) && propertyNameLookup.TryGetValue(property.PropertyName, out string newFieldName))
                property.PropertyName = newFieldName;
        }

        private static readonly Dictionary<Type, Dictionary<string, string>> typePropertyLookup = new Dictionary<Type, Dictionary<string, string>>
        {
            {
                typeof(NPPESResponse), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESResponse.Errors), "Errors" },
                    { nameof(NPPESResponse.ResultCount), "result_count" },
                    { nameof(NPPESResponse.Results), "results" }
                }
            },
            {
                typeof(NPPESResult), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESResult.Addresses), "addresses" },
                    { nameof(NPPESResult.Basic), "basic" },
                    { nameof(NPPESResult.Created), "created_epoch" },
                    { nameof(NPPESResult.EnumerationType), "enumeration_type" },
                    { nameof(NPPESResult.Identifiers), "identifiers" },
                    { nameof(NPPESResult.LastUpdated), "last_updated_epoch" },
                    { nameof(NPPESResult.Number), "number" },
                    { nameof(NPPESResult.OtherNames), "other_names" },
                    { nameof(NPPESResult.Taxonomies), "taxonomies" }
                }
            },
            {
                typeof(NPPESError), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESError.Description), "Description" },
                    { nameof(NPPESError.Field), "Field" },
                    { nameof(NPPESError.Number), "Number" }
                }
            },
            {
                typeof(NPPESAddress), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESAddress.Address1), "address_1" },
                    { nameof(NPPESAddress.Address2), "address_2" },
                    { nameof(NPPESAddress.AddressPurpose), "address_purpose" },
                    { nameof(NPPESAddress.AddressType), "address_type" },
                    { nameof(NPPESAddress.City), "city" },
                    { nameof(NPPESAddress.CountryCode), "country_code" },
                    { nameof(NPPESAddress.CountryName), "country_name" },
                    { nameof(NPPESAddress.FaxNumber), "fax_number" },
                    { nameof(NPPESAddress.PostalCode), "postal_code" },
                    { nameof(NPPESAddress.State), "state" },
                    { nameof(NPPESAddress.TelephoneNumber), "telephone_number" }
                }
            },
            {
                typeof(NPPESBasic), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESBasic.Credential), "credential" },
                    { nameof(NPPESBasic.EIN), "ein" },
                    { nameof(NPPESBasic.EnumerationDate), "enumeration_date" },
                    { nameof(NPPESBasic.FirstName), "first_name" },
                    { nameof(NPPESBasic.Gender), "gender" },
                    { nameof(NPPESBasic.Sex), "sex" },
                    { nameof(NPPESBasic.LastName), "last_name" },
                    { nameof(NPPESBasic.LastUpdated), "last_updated" },
                    { nameof(NPPESBasic.MiddleName), "middle_name" },
                    { nameof(NPPESBasic.NamePrefix), "name_prefix" },
                    { nameof(NPPESBasic.NameSuffix), "name_suffix" },
                    { nameof(NPPESBasic.OrganizationName), "organization_name" },
                    { nameof(NPPESBasic.ParentOrganizationLegalBusinessName), "parent_organization_legal_business_name" },
                    { nameof(NPPESBasic.ReplacementNPI), "replacement_npi" }
                }
            },
            {
                typeof(NPPESIdentifier), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESIdentifier.Code), "code" },
                    { nameof(NPPESIdentifier.Description), "desc" },
                    { nameof(NPPESIdentifier.Identifier), "identifier" },
                    { nameof(NPPESIdentifier.Issuer), "issuer" },
                    { nameof(NPPESIdentifier.State), "state" }
                }
            },
            {
                typeof(NPPESOtherName), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESOtherName.Code), "code" },
                    { nameof(NPPESOtherName.Credential), "credential" },
                    { nameof(NPPESOtherName.FirstName), "first_name" },
                    { nameof(NPPESOtherName.LastName), "last_name" },
                    { nameof(NPPESOtherName.MiddleName), "middle_name" },
                    { nameof(NPPESOtherName.OrganizationName), "organization_name" },
                    { nameof(NPPESOtherName.Prefix), "prefix" },
                    { nameof(NPPESOtherName.Suffix), "suffix" }
                }
            },
            {
                typeof(NPPESTaxonomy), new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { nameof(NPPESTaxonomy.Code), "code" },
                    { nameof(NPPESTaxonomy.Description), "desc" },
                    { nameof(NPPESTaxonomy.License), "license" },
                    { nameof(NPPESTaxonomy.Primary), "primary" },
                    { nameof(NPPESTaxonomy.State), "state" }
                }
            }
        };
    }
}

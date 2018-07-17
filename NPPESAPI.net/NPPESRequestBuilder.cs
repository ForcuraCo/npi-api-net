using Forcura.NPPES.Models;

namespace Forcura.NPPES
{
    public class NPPESRequestBuilder
    {
        private NPPESRequest request;

        public NPPESRequestBuilder()
        {
            request = new NPPESRequest();
        }

        public NPPESRequestBuilder Number(string number)
        {
            request.Number = number;
            return this;
        }

        public NPPESRequestBuilder Type(NPPESType? type)
        {
            request.EnumerationType = type;
            return this;
        }

        public NPPESRequestBuilder TaxonomyDescription(string description)
        {
            request.TaxonomyDescription = description;
            return this;
        }

        public NPPESRequestBuilder AddressPurpose(AddressPurpose? purpose)
        {
            request.AddressPurpose = purpose;
            return this;
        }

        public NPPESRequestBuilder FirstName(string firstName)
        {
            request.FirstName = firstName;
            return this;
        }

        public NPPESRequestBuilder LastName(string lastName)
        {
            request.LastName = lastName;
            return this;
        }

        public NPPESRequestBuilder OrganizationName(string orgName)
        {
            request.OrganizationName = orgName;
            return this;
        }

        public NPPESRequestBuilder City(string city)
        {
            request.City = city;
            return this;
        }

        public NPPESRequestBuilder State(string state)
        {
            request.State = state;
            return this;
        }

        public NPPESRequestBuilder PostalCode(string postalCode)
        {
            request.PostalCode = postalCode;
            return this;
        }

        public NPPESRequestBuilder CountryCode(string countryCode)
        {
            request.CountryCode = countryCode;
            return this;
        }

        public NPPESRequestBuilder Limit(int limit)
        {
            request.Limit = limit;
            return this;
        }

        public NPPESRequestBuilder Skip(int skip)
        {
            request.Skip = skip;
            return this;
        }

        public NPPESRequestBuilder Clear()
        {
            request = new NPPESRequest();
            return this;
        }

        public NPPESRequest Build()
        {
            return request;
        }
    }
}

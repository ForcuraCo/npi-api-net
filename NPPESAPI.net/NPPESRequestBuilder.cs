﻿using Forcura.NPPES.Models;

namespace Forcura.NPPES
{
    /// <summary>
    /// NPPES Request builder for a chainable method of building a request to provided to the NPPES NPI API.
    /// </summary>
    public class NPPESRequestBuilder
    {
        private NPPESRequest request;

        /// <summary>
        /// Creates an instance of the <see cref="NPPESRequestBuilder"/>
        /// </summary>
        public NPPESRequestBuilder()
        {
            request = new NPPESRequest();
        }

        /// <summary>
        /// Appends or updates the version to the request.
        /// </summary>
        /// <param name="version">The API version.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder Version(NPPESVersion version)
        {
            request.Version = version;
            return this;
        }

        /// <summary>
        /// Appends or updates an NPI number to the request.
        /// </summary>
        /// <param name="number">The NPI number.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder Number(string number)
        {
            request.Number = number;
            return this;
        }

        /// <summary>
        /// Appends or updates an <see cref="NPPESType"/>.
        /// </summary>
        /// <param name="type">The NPPES type.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder Type(NPPESType? type)
        {
            request.EnumerationType = type;
            return this;
        }

        /// <summary>
        /// Appends or updates a taxonomy description to the request.
        /// </summary>
        /// <param name="description">The taxonomy description.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder TaxonomyDescription(string description)
        {
            request.TaxonomyDescription = description;
            return this;
        }

        /// <summary>
        /// Appends or updates an <see cref="Models.AddressPurpose"/>.
        /// </summary>
        /// <param name="purpose">The address purpose.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder AddressPurpose(AddressPurpose? purpose)
        {
            request.AddressPurpose = purpose;
            return this;
        }

        /// <summary>
        /// Appends or updates the firstName search parameter for the request.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder FirstName(string firstName)
        {
            request.FirstName = firstName;
            return this;
        }

        /// <summary>
        /// Appends or updates the useFirstNameAlias search parameter for the request.
        /// </summary>
        /// <param name="useFirstNameAlias">Use first name alias.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder UseFirstNameAlias(bool useFirstNameAlias)
        {
            request.UseFirstNameAlias = useFirstNameAlias;
            return this;
        }

        /// <summary>
        /// Appends or updates the lastName search parameter for the request.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder LastName(string lastName)
        {
            request.LastName = lastName;
            return this;
        }

        /// <summary>
        /// Appends or updates the organizationName search parameter for the request.
        /// </summary>
        /// <param name="orgName">The organization name.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder OrganizationName(string orgName)
        {
            request.OrganizationName = orgName;
            return this;
        }

        /// <summary>
        /// Appends or updates the city search parameter for the request.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder City(string city)
        {
            request.City = city;
            return this;
        }

        /// <summary>
        /// Appends or updates the state search parameter for the request.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder State(string state)
        {
            request.State = state;
            return this;
        }

        /// <summary>
        /// Appends or updates the postalCode parameter for the request.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder PostalCode(string postalCode)
        {
            request.PostalCode = postalCode;
            return this;
        }

        /// <summary>
        /// Appends or updates the countryCode parameter for the request.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder CountryCode(string countryCode)
        {
            request.CountryCode = countryCode;
            return this;
        }

        /// <summary>
        /// Appends or updates the page size for the request. (default = 10, max = 200).
        /// </summary>
        /// <param name="limit">The maximum number of results to return.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder Limit(int limit)
        {
            request.Limit = limit;
            return this;
        }

        /// <summary>
        /// Appends or updates the number of results to skip when paging. (max = 1000).
        /// </summary>
        /// <param name="skip">The number of results to skip.</param>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder Skip(int skip)
        {
            request.Skip = skip;
            return this;
        }

        /// <summary>
        /// Clear the request parameters.
        /// </summary>
        /// <returns>The <see cref="NPPESRequestBuilder"/>.</returns>
        public NPPESRequestBuilder Clear()
        {
            request = new NPPESRequest();
            return this;
        }

        /// <summary>
        /// Build an instance of an NPPESRequest from the parameters provided to the builder.
        /// </summary>
        /// <returns>The <see cref="NPPESRequest"/>.</returns>
        public NPPESRequest Build()
        {
            return request;
        }
    }
}

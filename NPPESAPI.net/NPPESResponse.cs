using Forcura.NPPES.Models;
using System.Collections.Generic;
using System.Net;

namespace Forcura.NPPES
{
    /// <summary>
    /// Represents a response from the NPPES NPI API.
    /// </summary>
    public class NPPESResponse
    {
        /// <summary>
        /// Number of results returned in the response.
        /// </summary>
        public int ResultCount { get; set; }

        /// <summary>
        /// The search results, if any matches.
        /// </summary>
        public IList<NPPESResult> Results { get; set; }

        /// <summary>
        /// A list of errors returned from the API, if any.
        /// </summary>
        public IList<NPPESError> Errors { get; set; }

        /// <summary>
        /// The http status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}

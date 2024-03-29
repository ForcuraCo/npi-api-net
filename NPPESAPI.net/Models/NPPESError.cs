﻿namespace Forcura.NPPES.Models
{
    /// <summary>
    /// NPPES Error returned from the API.
    /// </summary>
    public class NPPESError
    {
        /// <summary>
        /// The field which caused the error response.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// The error code/number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Detailed description of the error.
        /// </summary>
        public string Description { get; set; }
    }
}

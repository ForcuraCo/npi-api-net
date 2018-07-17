using Forcura.NPPES.Models;
using System.Collections.Generic;

namespace Forcura.NPPES
{
    public class NPPESResponse
    {
        public int ResultCount { get; set; }
        public IList<NPPESResult> Results { get; set; }
        public IList<NPPESError> Errors { get; set; }
    }
}

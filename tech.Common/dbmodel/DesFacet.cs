using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Common.dbmodel
{
    public class DesFacet
    {
        public int DesFacetId { get; set; }
        public string FacetName { get; set; }

        // Foreign Key
        public int ResultId { get; set; }

        // Navigation property to Result
        public Result Result { get; set; }
    }
}

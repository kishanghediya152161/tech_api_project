using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Common.dbmodel
{
    public class Root
    {
        public int RootId { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string Section { get; set; }
        public DateTime LastUpdated { get; set; }
        public int NumResults { get; set; }

        // Navigation property for Result
        public ICollection<Result> Results { get; set; }
    }
}

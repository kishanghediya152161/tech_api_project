using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Common.ViewModel
{
    public class bookRequest
    {
        public string? key { get; set; }
        public string Section { get; set; }

        public int? pageNumber { get; set; }

        public int? numberOfElements { get; set; }
    }
}

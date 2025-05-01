using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Common.ViewModel
{
    public class MultimediumVM
    {
        public int id { get; set; }
        public string? url { get; set; }
        public string? format { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public string? type { get; set; }
        public string? subtype { get; set; }
        public string? caption { get; set; }
        public string? copyright { get; set; }
    }
}

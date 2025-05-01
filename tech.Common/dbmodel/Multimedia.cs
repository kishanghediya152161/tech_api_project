using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Common.dbmodel
{
    public class Multimedium
    {
        public int MultimediaId { get; set; }
        public string? Url { get; set; }
        public string? Format { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string? Type { get; set; }
        public string? Subtype { get; set; }
        public string? Caption { get; set; }
        public string? Copyright { get; set; }

        // Foreign Key
        public int ResultId { get; set; }

        // Navigation property to Result
        public Result Result { get; set; }
    }
}

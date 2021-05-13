using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class Files
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

    }
}

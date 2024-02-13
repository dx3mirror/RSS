using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntity
{
    public class News
    {
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Source { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

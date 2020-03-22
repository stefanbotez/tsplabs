using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public partial class Tags
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int MediaId { get; set; }

        public virtual Media Medium { get; set; }
    }
}

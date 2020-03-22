using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenariu4
{
    [Table("eCommerce", Schema = "Scenariu4")]
    public class eCommerce : Business
    {
        public string URL { get; set; }
    }
}

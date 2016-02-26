using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safmeds.Repository.Models
{
    public class Safmed
    {
        public int SafmedId { get; set; }
        public int Level { get; set; }
        public String Topic { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
    }
}

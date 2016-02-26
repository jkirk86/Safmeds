using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safmeds.Repository.Models
{
    public class SafmedSession
    {
        public int SafmedSessionId { get; set; }
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public DateTime SessionTime { get; set; }
        public int Level { get; set; }
        public String Topic { get; set; }
        public int Correct { get; set; }
        public int NotYet { get; set; }
    }
}

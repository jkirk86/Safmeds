using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safmeds.Web.ViewModels
{
    public class SafmedSessionViewModel
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
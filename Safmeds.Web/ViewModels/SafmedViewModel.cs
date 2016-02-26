using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safmeds.Web.ViewModels
{
    public class SafmedViewModel
    {
        public int SafmedId { get; set; }
        public int Level { get; set; }
        public String Topic { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
    }
}
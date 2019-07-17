using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI2Aurimas.Models
{
    public class HugModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Reason { get; set; }
        public DateTime Created { get; set; }
    }
}

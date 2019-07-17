using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_demo.Controllers
{
    public class Hug
    {
        public long Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }

        public Hug(long id, string reason, DateTime date)
        {
            Id = id;
            Reason = reason;
            Date = date;
        }
    }
}

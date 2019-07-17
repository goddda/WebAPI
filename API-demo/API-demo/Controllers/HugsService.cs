using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_demo.Controllers
{
    public class HugsService
    {
        public int GetHugsAtMonthCount(int month, List<Hug> hugs)
        {
            return hugs.FindAll(hug => hug.Date.Month == month).Count;

        }
    }
}

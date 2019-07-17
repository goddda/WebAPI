using System;
using System.Collections.Generic;
using System.Text;

namespace HugDb.Entities
{
    public class Committee
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public List<UserCommittee> UserCommittees { get; set; }

        public List<Hug> Hugs { get; set; }
    }
}

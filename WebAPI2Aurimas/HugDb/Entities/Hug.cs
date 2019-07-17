using System;
using System.Collections.Generic;
using System.Text;

namespace HugDb.Entities
{
    public class Hug
    {
        public int Id { get; set; }
        public User FromUser { get; set; }
        public User ToUser { get; set; }
        public int Value { get; set; }
        public bool Used { get; set; }
        public DateTime Created { get; set; }
    }
}

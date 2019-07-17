using System;
using System.Collections.Generic;
using System.Text;

namespace HugDb.Entities
{
    public class UserCommittee
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Committee Committee { get; set; }
        public int UserId { get; set; }
        public int CommitteeId { get; set; }
    }
}

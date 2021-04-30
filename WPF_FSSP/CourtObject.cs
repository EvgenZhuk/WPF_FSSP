using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class CourtObject
    {
        public CourtObject()
        {
            CourtStations = new HashSet<CourtStation>();
            UserRoles = new HashSet<UserRole>();
            Visitors = new HashSet<Visitor>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public bool AccessControlSystem { get; set; }
        public string AccessControlSystemUrl { get; set; }

        public virtual ICollection<CourtStation> CourtStations { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}

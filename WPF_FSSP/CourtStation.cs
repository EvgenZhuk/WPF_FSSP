using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class CourtStation
    {
        public CourtStation()
        {
            VisitorToCourtStations = new HashSet<VisitorToCourtStation>();
        }

        public long Id { get; set; }
        public long CourtObjectId { get; set; }
        public int Number { get; set; }

        public virtual CourtObject CourtObject { get; set; }
        public virtual ICollection<VisitorToCourtStation> VisitorToCourtStations { get; set; }
    }
}

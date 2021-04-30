using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class VisitorToCourtStation
    {
        public long Id { get; set; }
        public long VisitorId { get; set; }
        public long CourtStationId { get; set; }

        public virtual CourtStation CourtStation { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}

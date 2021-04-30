using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class AcsSessionsInfo
    {
        public long Id { get; set; }
        public string SessionId { get; set; }
        public long VisitorId { get; set; }
        public bool IsForgotten { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}

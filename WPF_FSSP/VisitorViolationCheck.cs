using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class VisitorViolationCheck
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int? FsspCheckResult { get; set; }
        public int? MiaCheckResult { get; set; }
        public long VisitorId { get; set; }
        public string FsspCommentary { get; set; }
        public string MiaCommentary { get; set; }
        public int? CovidCheckResult { get; set; }
        public DateTime? CovidQuarantineEndDate { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}

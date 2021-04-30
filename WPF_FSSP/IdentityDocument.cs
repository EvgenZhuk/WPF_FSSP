using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class IdentityDocument
    {
        public IdentityDocument()
        {
            IdentityDocumentImages = new HashSet<IdentityDocumentImage>();
        }

        public long Id { get; set; }
        public string Number { get; set; }
        public long VisitorId { get; set; }
        public byte[] PortraitImageBytes { get; set; }
        public string PortraitImageFormat { get; set; }
        public DateTime CreationDate { get; set; }
        public int? DocumentType { get; set; }

        public virtual Visitor Visitor { get; set; }
        public virtual IdentityDocumentAuthenticityResult IdentityDocumentAuthenticityResult { get; set; }
        public virtual IdentityDocumentComparisonInfo IdentityDocumentComparisonInfo { get; set; }
        public virtual ICollection<IdentityDocumentImage> IdentityDocumentImages { get; set; }
    }
}

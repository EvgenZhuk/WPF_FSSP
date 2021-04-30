using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class IdentityDocumentComparisonInfo
    {
        public long Id { get; set; }
        public int MrzWithRfid { get; set; }
        public int MrzWithText { get; set; }
        public int MrzWithBarcode { get; set; }
        public int TextWithRfid { get; set; }
        public int TextWithBarcode { get; set; }
        public int RfidWithBarcode { get; set; }
        public long IdentityDocumentId { get; set; }

        public virtual IdentityDocument IdentityDocument { get; set; }
    }
}

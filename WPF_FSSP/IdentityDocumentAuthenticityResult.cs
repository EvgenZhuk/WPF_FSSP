using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class IdentityDocumentAuthenticityResult
    {
        public long Id { get; set; }
        public int BlankLuminescence { get; set; }
        public int MrzLuminescence { get; set; }
        public int PhotoLuminescence { get; set; }
        public int MrzPrintContrast { get; set; }
        public int FibersLuminescence { get; set; }
        public int IrBlankVisibility { get; set; }
        public int IrPhotoVisibility { get; set; }
        public int IrFillVisibility { get; set; }
        public int HiddenPhotoVisualization { get; set; }
        public int PhotoEmbedding { get; set; }
        public int PhotoEmbedType { get; set; }
        public int BarcodeFormat { get; set; }
        public int Holograms { get; set; }
        public int RetroflexProtection { get; set; }
        public int ImagePattern { get; set; }
        public long IdentityDocumentId { get; set; }

        public virtual IdentityDocument IdentityDocument { get; set; }
    }
}

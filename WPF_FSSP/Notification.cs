using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class Notification
    {
        public long Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public string InformationText { get; set; }
        public int NotificationType { get; set; }
    }
}

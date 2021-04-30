using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class PathmanConcurrentPartTask
    {
        public int? Pid { get; set; }
        public uint? Dbid { get; set; }
        public int? Processed { get; set; }
        public string Status { get; set; }
    }
}

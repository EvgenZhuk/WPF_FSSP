using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class PathmanCacheStat
    {
        public string Context { get; set; }
        public long? Size { get; set; }
        public long? Used { get; set; }
        public long? Entries { get; set; }
    }
}

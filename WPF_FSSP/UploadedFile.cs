﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class UploadedFile
    {
        public long Id { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long SizeInBytes { get; set; }
        public int Type { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}

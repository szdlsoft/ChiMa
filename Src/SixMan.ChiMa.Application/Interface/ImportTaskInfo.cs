using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Interface
{
    public sealed class ImportTaskInfo
    {
        public string TaskId { get; set; }
        public bool IsRunning { get; set; }
        public bool Complete { get; set; }
        public bool Cancel { get; set; }
        public int Percent { get; set; }
    }
}

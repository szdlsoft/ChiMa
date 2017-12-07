using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Interface
{
    public sealed class ImportTaskInfo
    {
        public bool Complete { get; set; }
        public bool Cancel { get; set; }
        public double Percent { get; set; }
    }
}

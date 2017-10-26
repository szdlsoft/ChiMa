using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Common
{
    /// <summary>
    /// 范围
    /// </summary>
    [ComplexType]
    public class Range
    {
        public int? From { get; set; }
        public int? To { get; set; }
    }
}

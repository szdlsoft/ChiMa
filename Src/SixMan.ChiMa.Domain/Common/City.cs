using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Common
{
    public class City
        : CategoryBase
    {
        /// <summary>
        /// 父节点
        /// </summary>
        [ForeignKey("ParentId")]
        public City Parent { get; set; }
    }
}

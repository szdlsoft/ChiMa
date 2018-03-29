using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 人员健康影响
    /// </summary>
    public class PersonHealthAffect
        : ChiMaEntityBase
        , IAffectDegree
    {
        public FamilyMember FamilyMember { get; set; }
        public HealthConcern HealthConcern { get; set; }
        /// <summary>
        /// 影响程度
        /// </summary>
        public int AffectDegree { get; set; }
    }
}

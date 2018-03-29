using Abp.Domain.Entities;
using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Common
{
    public class Area
        : ChiMaSmallEntityBase
    {
        /// <summary>
        /// 名称'
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// '简称'
        /// </summary>
        public string SHORT_NAME { get; set; }
        /// <summary>
        /// '经度'
        /// </summary>
        public double LONGITUDE { get; set; }
        /// <summary>
        /// '纬度'
        /// </summary>
        public double LATITUDE { get; set; }
        /// <summary>
        /// '等级(1省/直辖市,2地级市,3区县,4镇/街道)'
        /// </summary>
        public Level LEVEL { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int SORT { get; set; }
        /// <summary>
        /// '状态(0禁用/1启用)'
        /// </summary>
        public bool STATUS { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        [ForeignKey("Parent_Id")]
        public Area Parent { get; set; }

        public enum Level
            : byte
        {
            Province=1,
            City=2,
            County=3,
            Street=4,
        }
    }

}

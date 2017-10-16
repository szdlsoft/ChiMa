using Sixman.Chima.Domain.Base;
using Sixman.Chima.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sixman.Chima.Domain.Dish
{
    /// <summary>
    /// 烹饪法步骤
    /// </summary>
    public class Cookery
        : DescriptionBase
        , IOrder
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        [StringLength(512)]
        public string Photo { get; set; }
        /// <summary>
        /// 音频
        /// </summary>
        [StringLength(512)]
        public string Audio { get; set; }
        /// <summary>
        /// 视频
        /// </summary>
        [StringLength(512)]
        public string Video { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int? Time { get; set; }
    }
}

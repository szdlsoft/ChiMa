using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class DishDetailsRawData
        : List<DishDetailsRawDataItem>
    {
    }

    public class DishDetailsRawDataItem
    {
        /// <summary>
        /// 菜名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 大图像
        /// </summary>
        public string SmallImageUrl { get; set; }
        /// <summary>
        /// 大图像
        /// </summary>
        public string BigImageUrl { get; set; }
        /// <summary>
        /// 详请URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 各种分类标签
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 烹饪步骤
        /// </summary>
        public CookeryRawData Cookery { get; set; }
        /// <summary>
        /// 食材配比
        /// </summary>
        public DishBomRawData DishBom { get; set; }
    }

    public class DishBomRawData
    {
    }

    public class CookeryRawData
    {
    }
}

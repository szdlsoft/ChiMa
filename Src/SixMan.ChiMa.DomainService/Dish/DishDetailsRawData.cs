using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class DishDetailsRawData
        : List<DishDetailsRawDataItem>
        , ICrawlerObject
    {
        public string Tag { get; set; }

        [JsonIgnore]
        public string CrawlerFileName => Tag.Replace(",", "_");
    }

    public class DishDetailsRawDataItem
    {
        public string DataId { get; set; }
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
        /// 口味
        /// </summary>
        public string Taste { get; set; }

        /// <summary>
        /// 烹饪时间
        /// </summary>
        public string CookTime { get; set; }
        /// <summary>
        /// 制作难度
        /// </summary>
        public string Difficulty { get; set; }
        /// <summary>
        /// 工艺
        /// </summary>
        public string Technology { get; set; }

        /// <summary>
        /// 烹饪步骤
        /// </summary>
        public CookeryRawData Cookery { get; set; }
        /// <summary>
        /// 主材 食材配比
        /// </summary>
        public DishBomRawData DishBom { get; set; }

        /// <summary>
        /// 辅材 食材配比
        /// </summary>
        public DishBomRawData AuxDishBom { get; set; }
    }

    public class DishBomRawData
        : List<BomItem>
    {
    }

    public class CookeryRawData
        : List<CookeyItem>
    {
        public CookeryRawData(List<CookeyItem> steps)
        {
            AddRange(steps);
        }
    }
    /// <summary>
    /// 食材配比
    /// </summary>
    public class BomItem
    {
        public string EnglishName { get; set; }
        public string FoodMaterialName { get; set; }
        public string Use { get; set; }
    }
    /// <summary>
    /// 烹饪步骤
    /// </summary>
    public class CookeyItem
    {
        /// <summary>
        /// 序号
        /// </summary>
        //public int Order { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Photo { get; set; }

    }
}

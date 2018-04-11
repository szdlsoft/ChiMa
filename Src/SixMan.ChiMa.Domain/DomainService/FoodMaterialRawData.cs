using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SixMan.ChiMa.Domain
{
    public class FoodMaterialRawData
        : List<FoodMaterialRawDataItem>
    {
        public int TopCount => this.Select(x => x.Top).Distinct().Count();
        public int MiddleCount => this.Select(x => x.Middle).Distinct().Count();
        public int MaterialCount => this.SelectMany(x => x.FoodMaterials).Count();
    }

    public class FoodMaterialRawDataItem
    {
        /// <summary>
        /// 大类
        /// </summary>
        public string Top { get; set; }
        /// <summary>
        /// 中类
        /// </summary>
        public string Middle { get; set; }
        /// <summary>
        /// 分类食材
        /// </summary>
        public FoodMaterialCollection FoodMaterials { get; set; }

    }

    public class FoodMaterialCollection
        : List<FooMaterialItem>
    {

    }

    /// <summary>
    /// 食材
    /// </summary>
    public class FooMaterialItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 英文名（拼音）
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 来源页
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 营养成分
        /// </summary>
        public List<string> Nutritions { get; set; }

    }
}

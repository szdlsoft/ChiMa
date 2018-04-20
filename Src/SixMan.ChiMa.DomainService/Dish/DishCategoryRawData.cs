using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class DishCategoryRawData 
        : List<DishCategoryRawDataItem>

    {
         
    }

    public class DishCategoryRawDataItem
    {
        /// <summary>
        /// 类别，有多个以,来分割
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 类别对应的 列表URL
        /// </summary>
        public string ListUrl { get; set; }
        /// <summary>
        /// 该类 页数
        /// </summary>
        public int PagesNumber { get; set; }
        /// <summary>
        /// 需要爬
        /// </summary>
        public bool NeedCrawl { get; set; }
        /// <summary>
        /// Tag 转文件名
        /// </summary>
        [JsonIgnore]
        public string FileName => "DishList_" +  Tag.Replace(",", "_");
    }
}

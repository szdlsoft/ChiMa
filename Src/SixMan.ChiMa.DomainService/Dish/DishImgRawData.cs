using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    /// <summary>
    /// 菜品图像RawData
    /// </summary>
    public class DishImgRawData
        : List<DishImgItem>
    {
        public DishImgRawData(IEnumerable<DishImgItem> imgs)
        {
            AddRange(imgs);
        }
    }
    /// <summary>
    /// 菜品图像
    /// </summary>
    public class DishImgItem 
        : IEqualityComparer<DishImgItem>
    {
        /// <summary>
        /// 本地存放相对路径
        /// </summary>
        public string LocalPath { get; set; }       
        /// <summary>
        /// 来源url
        /// </summary>
        public string SourcrUrl { get; set; }

        public bool Equals(DishImgItem x, DishImgItem y)
        {
            return x.SourcrUrl == y.SourcrUrl;
        }

        public int GetHashCode(DishImgItem obj)
        {
            return obj.SourcrUrl.GetHashCode();
        }
    }
}

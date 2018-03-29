using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Interface
{
    /// <summary>
    /// 多媒体
    /// </summary>
    public interface IMultiMedia
    {
        /// <summary>
        /// 照片
        /// </summary>
        string Photo { get; set; }
        /// <summary>
        /// 音频
        /// </summary>
        string Audio { get; set; }
        /// <summary>
        /// 视频
        /// </summary>
        string Video { get; set; }
    }
}

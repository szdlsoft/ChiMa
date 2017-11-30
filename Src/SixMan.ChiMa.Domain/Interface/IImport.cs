using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Interface
{
    /// <summary>
    /// 导入数据
    /// </summary>
    /// <param name="row"></param>
    public interface IImport
    {
        void Import(Dictionary<string, string> row);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Interface
{
    /// <summary>
    /// 从excel,导入
    /// </summary>
    public interface IImportFromExcel
    {
        int Import(List<Dictionary<string, string>> importData);

        ImportTaskInfo BuildImportWork(List<Dictionary<string, string>> importData, string taskId);

        ImportTaskInfo QueryWork(string taskId);

        ImportTaskInfo CancelWork(string taskId);
    }
}

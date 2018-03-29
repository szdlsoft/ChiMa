using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Tools2
{
    public static class NameConvert
    {
        /**
	 * 将驼峰式命名的字符串转换为下划线大写方式。如果转换前的驼峰式命名的字符串为空，则返回空字符串。</br>
	 * 例如：HelloWorld->HELLO_WORLD
	 * @param name 转换前的驼峰式命名的字符串
	 * @return 转换后下划线大写方式命名的字符串
	 */
        public static String underscoreName(String name)
        {
            StringBuilder result = new StringBuilder();
            if (name != null && name.Length > 0)
            {
                // 将第一个字符处理成大写
                result.Append(name.Substring(0, 1).ToUpper());
                // 循环处理其余字符
                for (int i = 1; i < name.Length; i++)
                {
                    String s = name.Substring(i, i + 1);
                    // 在大写字母前添加下划线
                    if (s.Equals(s.ToUpper()) && !Char.IsDigit(s[0]))
                    {
                        result.Append("_");
                    }
                    // 其他字符直接转成大写
                    result.Append(s.ToUpper());
                }
            }
            return result.ToString();
        }

        /**
         * 将下划线大写方式命名的字符串转换为驼峰式。如果转换前的下划线大写方式命名的字符串为空，则返回空字符串。</br>
         * 例如：HELLO_WORLD->HelloWorld
         * @param name 转换前的下划线大写方式命名的字符串
         * @return 转换后的驼峰式命名的字符串
         */
        public static String camelName(String name)
        {
            StringBuilder result = new StringBuilder();
            // 快速检查
            if (name == null || string.IsNullOrEmpty( name))
            {
                // 没必要转换
                return "";
            }
            //else if (!name.Contains("_"))
            //{
            //    // 不含下划线，仅将首字母小写
            //    return name.Substring(0, 1).ToLower() + name.Substring(1);
            //}
            // 用下划线将原始字符串分割
            String[] camels = name.Split('_');
            foreach (String camel in  camels)
            {
                // 跳过原始字符串中开头、结尾的下换线或双重下划线
                if (string.IsNullOrEmpty( camel))
                {
                    continue;
                }
                // 处理真正的驼峰片段
                //if (result.Length == 0)
                //{
                //    // 第一个驼峰片段，全部字母都小写
                //    result.Append(camel.ToLower());
                //}
                //else
                {
                    // 其他的驼峰片段，首字母大写
                    result.Append(camel.Substring(0, 1).ToUpper());
                    result.Append(camel.Substring(1).ToLower());
                }
            }
            return result.ToString();
        }


    }
}

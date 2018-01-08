using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace testTwo
{
    class ManagerClass
    {
        public void ShowClas()
        {
            Console.WriteLine("可以查看笔记类型");
            String text = string.Empty;
            StreamReader sr = new StreamReader(@"E:\C#\testTwo\testTwo.txt");
            text = sr.ReadToEnd();//调用该方法读取文件中的全部内容
            Console.WriteLine(text);
            sr.Close();
        }
    }
}

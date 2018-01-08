using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace testTwo
{
    class NewNote
    {
        public void Newnote()
        {
            Console.WriteLine("请输入内容");
            StreamWriter sw = new StreamWriter(@"E:\C#\testTwo\testTwo.txt", true);
            sw.WriteLine("内容：");
            sw.WriteLine(Console.ReadLine());
            sw.Flush();
            sw.Close();
            Console.WriteLine("笔记本已新建完成");
            Console.ReadKey();
        }
    }
}

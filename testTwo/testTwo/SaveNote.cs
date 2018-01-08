using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace testTwo
{
    class SaveNote
    {
        public void Savenote()
        {
            Console.WriteLine("请输入笔记：");
            String text = Console.ReadLine();
            StreamWriter sw = new StreamWriter(@"E:\C#\testTwo\testTwo.txt");
            sw.WriteLine(text);
            Console.WriteLine("笔记已保存成功");
            sw.Close();
            Console.ReadKey();
        }
    }
}

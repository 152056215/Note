using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("####################################");
            Console.WriteLine("#    1.新建笔记本      2.打开笔记本#");
            Console.WriteLine("#    3.新建分类        4.管理分类  #");
            Console.WriteLine("#    5.保存笔记        6.退出      #");
            Console.WriteLine("####################################");
           
            Console.WriteLine("请输入菜单选项1~6");
            String key= Console.ReadLine();
            switch (key)
            {
                case "1":
                    NewNote newnote = new NewNote();
                    newnote.Newnote();
                    break;
                case "2":
                    OpenNote openote = new OpenNote();
                    openote.Opennote();
                    break;
                case "3":
                    NewClass newclass = new NewClass();
                    newclass.Newclass();
                    break;
                case "4":
                    ManagerClass mc = new ManagerClass();
                    mc.ShowClas();
                    break;
                case "5":
                    SaveNote sn = new SaveNote();
                    sn.Savenote();
                    break;
                case"6":
                    Console.WriteLine("退出");
                    break;
                default:
                    Console.WriteLine("请输入1~6的数字");
                    break;
            }
               Console.ReadKey();
        }
    }
}
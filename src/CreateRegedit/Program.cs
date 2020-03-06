using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
namespace CreateRegedit
{
    class Program
    {
        static void Main(string[] args)
        {
            //HKEY_CLASSES_ROOT\Directory\Background\shell
            RegistryKey key = Registry.ClassesRoot;
            RegistryKey directory = key.OpenSubKey("Directory");
            RegistryKey Background = directory.OpenSubKey("Background");
            RegistryKey shell = Background.OpenSubKey("shell", true);
            
            try
            {
                if (!shell.GetSubKeyNames().Contains("Menu_Date"))
                {

                    Console.WriteLine("开始写入注册表");

                    RegistryKey Menu_Date = shell.CreateSubKey("Menu_Date");
                    Menu_Date.SetValue("", "新建日期文件夹");
                    var command = Menu_Date.CreateSubKey("command");
                    command.SetValue("", @"C:\ContextMenu\Menu_Date.exe");
                    Console.WriteLine("新建右键菜单“新建日期文件夹” Success");


                }
                if (!shell.GetSubKeyNames().Contains("Menu_Time"))
                {
                    Console.WriteLine("开始写入注册表");

                    RegistryKey Menu_Time = shell.CreateSubKey("Menu_Time");
                    Menu_Time.SetValue("", "新建时间文件夹");
                    var command = Menu_Time.CreateSubKey("command");
                    command.SetValue("", @"C:\ContextMenu\Menu_Time.exe");

                    Console.WriteLine("新建右键菜单“新建时间文件夹” Success");

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("发生错误：" + ex.ToString());

            }
            Console.WriteLine("可以关闭当前窗口了");

            Console.ReadKey();

        }



    }
}

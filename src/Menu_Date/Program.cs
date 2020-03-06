using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Menu_Date
{
    class Program
    {
        static void Main(string[] args)
        {
            var cPath = Directory.GetCurrentDirectory();
            string dir = DateTime.Now.ToString("yyyy-MM-dd");
            var NameList = Directory.GetDirectories(cPath).Select(p => Path.GetFileName(p)).ToList();
            var i = 0;
            while (NameList.Exists(p => p == (dir + (i == 0 ? "" : ("-" + i)))))
            {
                i++;
            }
            if (i == 0)
            {
                Directory.CreateDirectory(Path.Combine(cPath, dir));
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(cPath, $"{dir}-{i}"));
            }
        }
    }
}

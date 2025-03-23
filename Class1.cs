using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysinfo
{
    internal class FilePath
    {
        public static string GetPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        public static string GetFullPath()
        {
            return System.IO.Path.GetFullPath(GetPath());
        }

       
    }
    public static class FunnyGif
    {
        public static Uri Morning = new Uri("ms-appx:///Assets/gift/morning.gif");
    }
      
    }

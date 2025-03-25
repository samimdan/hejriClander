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
        
        public static Uri waa = new Uri("ms-appx:///Assets/gift/_d-2x.gif");
        public static Uri aaa = new Uri("ms-appx:///Assets/gift/aaa-2x.gif");
        public static Uri BOOBA = new Uri("ms-appx:///Assets/gift/BOOBA-2x.gif");
        public static Uri catKISS = new Uri("ms-appx:///Assets/gift/catKISS-2x.gif");
        public static Uri docnotL = new Uri("ms-appx:///Assets/gift/docnotL.gif");
        public static Uri HARAM = new Uri("ms-appx:///Assets/gift/HARAM.gif");
        public static Uri HUH = new Uri("ms-appx:///Assets/gift/HUH.gif");
        public static Uri lookBoth = new Uri("ms-appx:///Assets/gift/lookBoth.gif");
        public static Uri Mad = new Uri("ms-appx:///Assets/gift/MAD.gif");
        public static Uri SusageSit = new Uri("ms-appx:///Assets/gift/SusgeSit.png");
        //generate mothod that return random uri from FunnyGif 
        public static Uri GetRandomGif()
        {
            var random = new Random();
            Uri[] uris = new Uri[] { waa, aaa, BOOBA, catKISS, docnotL, HARAM, HUH, lookBoth, Mad };
            return uris[random.Next(uris.Length)];
        }
    }


}
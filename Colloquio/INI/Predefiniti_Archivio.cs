using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colloquio
{
    public static class Predefiniti_Archivio       
    {
        static string section = "Archivio";
        static string[] key = new string[] { "SQL ArchivioPath", "CatalogName", "MaxStorageDays", "MaxStorageDaysCheckInterval" };
        static string[] valueProperty = new string[] { "CLEARCANVAS64PC\"IMAGESERVER2", "FastprintProDoca", "1000" , "10"};
        public static string Section { get => section; set => section = value; }
        public static string[] Key { get => key; set => key = value; }
        public static string[] ValueProperty { get => valueProperty; set => valueProperty = value; }
    }
}

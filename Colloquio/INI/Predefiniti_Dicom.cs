using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colloquio
{
    public static class Predefiniti_Dicom        //predefiniti ini Dimcom
    {
        static string section = "Dicom";
        static string[] key = new string[] { "DCMColPrintProcessServerAdditionalOptions", "DCMBNPrintProcessServerAdditionalOptions" };
        static string[] valueProperty = new string[] { "-v -d +d", "-v -d" };
        public static string Section { get => section; set => section = value; }
        public static string[] Key { get => key; set => key = value; }
        public static string[] ValueProperty { get => valueProperty; set => valueProperty = value; }
    }
}

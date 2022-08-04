using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colloquio
{
    public static class Predefiniti_StampaServer         //predefiniti ini StampaServer
    {
        static string section = "StampaServer";
        static string[] key = new string[] { "StampaServerEnabled" , "UpdateInterval" };
        static string[] valueProperty = new string[] { "1", "3" };
        public static string Section { get => section; set => section = value; }
        public static string[] Key { get => key; set => key = value; }
        public static string[] ValueProperty { get => valueProperty; set => valueProperty = value; }
    }
}

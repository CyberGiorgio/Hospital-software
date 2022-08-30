using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Colloquio.StaticClasses.JSONFile;

namespace Colloquio.StaticClasses
{
    static public class JSONFile
    {
        public class Esame{
            private string nomeEsame;       //attributes esame class
            private string codiceMinisteriale;
            private string codiceInterno;
            private string descrizione;
            private DateTime localDate;
            public Esame()      //empty constructor
            {
            }
            public Esame(string nomeEsame, string codiceMinisteriale, string codiceInterno, string descrizione, DateTime localDate)
            {
                this.nomeEsame = nomeEsame;
                this.codiceMinisteriale = codiceMinisteriale;
                this.codiceInterno = codiceInterno;
                this.descrizione = descrizione;
                this.localDate = localDate;
            }
            public string NomeEsame { get => nomeEsame; set => nomeEsame = value; }         //encapsulation
            public string CodiceMinisteriale { get => codiceMinisteriale; set => codiceMinisteriale = value; }
            public string CodiceInterno { get => codiceInterno; set => codiceInterno = value; }
            public string Descrizione { get => descrizione; set => descrizione = value; }
            public DateTime LocalDate { get => localDate; set => localDate = value; }
        }
        public static void Serialize(ListView listViewEsamiAggiunti)        //serialize json objects into list
        {
            List<Esame> listEsami = new List<Esame>();
            for (int i = 0; i < listViewEsamiAggiunti.Items.Count; i++)
            {
                    var esame = new Esame()
                    {
                        LocalDate = DateTime.Now,
                        NomeEsame = listViewEsamiAggiunti.Items[i].SubItems[1].Text,
                        CodiceMinisteriale = listViewEsamiAggiunti.Items[i].SubItems[2].Text,
                        CodiceInterno = listViewEsamiAggiunti.Items[i].SubItems[3].Text,
                        Descrizione = listViewEsamiAggiunti.Items[i].SubItems[4].Text
                    };
                    listEsami.Add(esame);
            }
            var json = JsonConvert.SerializeObject(listEsami);      //serialize list
            string fileName = "esami.json";             
            File.WriteAllText(fileName, json);          //save file name with the name stated above
        }
    }
}

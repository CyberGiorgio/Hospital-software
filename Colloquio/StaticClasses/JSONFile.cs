using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Colloquio.StaticClasses
{
    static public class JSONFile
    {
        public static void Serialize(ListView listViewEsamiAggiunti)        //serialize json objects into list
        {
            TodayDate today = new TodayDate();
            today.DateTime = DateTime.Today.ToString("dd-MM-yyyy");
            today.Esami = new List<Esame>();
            List<Esame> listEsami = new List<Esame>();
            for (int i = 0; i < listViewEsamiAggiunti.Items.Count; i++)     //create a list of esami
            {
                    var esame = new Esame()
                    {
                        NomeEsame = listViewEsamiAggiunti.Items[i].SubItems[1].Text,
                        CodiceMinisteriale = listViewEsamiAggiunti.Items[i].SubItems[2].Text,
                        CodiceInterno = listViewEsamiAggiunti.Items[i].SubItems[3].Text,
                        Descrizione = listViewEsamiAggiunti.Items[i].SubItems[4].Text
                    };
                today.Esami.Add(esame);
            }
            var json = JsonConvert.SerializeObject(today);      //serialize list
            string fileName = "esami-"+ today.DateTime +".json";             
            File.WriteAllText(fileName, json);          //save file name with the name stated above
        }
    }
    public class TodayDate
    {
        private string dateTime;        //date and list of exams
        private List<Esame> esami;
        public string DateTime { get => dateTime; set => dateTime = value; }        //encapsulation
        public List<Esame> Esami { get => esami; set => esami = value; }
    }
    public class Esame
    {
        private string nomeEsame;       //attributes esame class
        private string codiceMinisteriale;
        private string codiceInterno;
        private string descrizione;
        public Esame()      //empty constructor
        {
        }
        public Esame(string nomeEsame, string codiceMinisteriale, string codiceInterno, string descrizione)
        {
            this.nomeEsame = nomeEsame;
            this.codiceMinisteriale = codiceMinisteriale;
            this.codiceInterno = codiceInterno;
            this.descrizione = descrizione;
        }
        public string NomeEsame { get => nomeEsame; set => nomeEsame = value; }         //encapsulation
        public string CodiceMinisteriale { get => codiceMinisteriale; set => codiceMinisteriale = value; }
        public string CodiceInterno { get => codiceInterno; set => codiceInterno = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
    }
}

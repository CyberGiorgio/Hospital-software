using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace Colloquio
{
    public partial class Form1 : Form
    {
        public static DataSet dsAmbulatori = new DataSet();
        public static DataSet dsPartiCorpo = new DataSet();
        public static DataSet dsEsami = new DataSet();
   
        public Form1()
        {
            InitializeComponent();
            textBoxScriviQui.LostFocus += new EventHandler(TextBoxScriviQui_LostFocus);     //event when click outside "Scrivi qui" added
            this.Shown += new EventHandler(Form1_Shown);

            INIFile iNIFile = new INIFile("Settings.ini");  //load ini config
            string [] stampaServer = INIFile.LoadConfigurationINI().Item1;
            string[] archivio = INIFile.LoadConfigurationINI().Item2;
            string[] dimcom = INIFile.LoadConfigurationINI().Item2;
        }
        private void Form1_Shown(object sender, EventArgs e)                        //event select index 0
        {
           listBoxAmbulatori.SelectedIndex = 0;     //default index
        }
        private void TextBoxScriviQui_LostFocus(object sender, EventArgs e)         //event when click outside "Scrivi qui"
        {
            if (textBoxScriviQui.Text == ""){
                textBoxScriviQui.Text = "Scrivi qui";
                textBoxScriviQui.ForeColor = Color.Gray;
            }
        }
        private void TextBoxScriviQui_Click(object sender, EventArgs e)           //event when click on "Scrivi qui"
        {
            if(textBoxScriviQui.Text == "Scrivi qui")
            {
                textBoxScriviQui.Text = "";
                textBoxScriviQui.ForeColor = Color.Black;
            }
        }
        private void OnLoadData(object sender, EventArgs e)     //onload function executed (connection to database and initialise data)
        {
            LogicSearch.DbConnect();

            LogicSearch.LoadColumnEsami(listViewEsami);         //load grid columns Esami listView
            LogicSearch.LoadColumnEsami(listViewEsamiAggiunti);

            LogicSearch.LoadDatasetFromDatabase("ambulatori", dsAmbulatori);       //get data ambulatori lists
            LogicSearch.AddItemsToListFromDatabase(listBoxAmbulatori, dsAmbulatori);
            LogicSearch.LoadDatasetFromDatabase("partiCorpo", dsPartiCorpo);        //get data partiCorpo lists
            LogicSearch.AddItemsToListFromDatabase(listBoxPartiCorpo, dsPartiCorpo);
        }
        private void ButtonCerca_Click(object sender, EventArgs e)  //click on cerca
        {
            int indexComboBox = comboBoxRicerca.SelectedIndex;
            LogicSearch.SearchByBox(textBoxScriviQui.Text, indexComboBox, listViewEsami, listBoxAmbulatori,listBoxPartiCorpo);      //search by SearchBox
        }
        private void TextBoxScriviQui_KeyDown(object sender, KeyEventArgs e)    //press enter cerca
        {
            if (e.KeyCode == Keys.Enter)
            {
                int indexComboBox = comboBoxRicerca.SelectedIndex;
                e.Handled = true;       //remove sound when press enter
                e.SuppressKeyPress = true;
                LogicSearch.SearchByBox(textBoxScriviQui.Text, indexComboBox, listViewEsami, listBoxAmbulatori, listBoxPartiCorpo);
            }
        }
        private void ButtonAggiungi_Click(object sender, EventArgs e)       //add Esame to Esami aggiunti table
        {
            LogicSearch.AddItemToEsamiAggiunti(listViewEsami, listViewEsamiAggiunti);
        }
        private void ButtonRemove_Click(object sender, EventArgs e)     //remove item from Esami Aggiunti
        {
            LogicSearch.RemoveEsamiAggiunti(listViewEsamiAggiunti);
        }
        private void ListBoxPartiCorpo_MouseClick(object sender, MouseEventArgs e) // this will fire every time items are selected or deselected.
        {
            if (LogicSearch.GetAbmulatorioANDPartiCorpoSelected(listBoxAmbulatori,listBoxPartiCorpo).Item1 >= 0 && LogicSearch.GetAbmulatorioANDPartiCorpoSelected(listBoxAmbulatori, listBoxPartiCorpo).Item2 >= 0)
            {
                LogicSearch.SearchByIndexes(listBoxAmbulatori, listBoxPartiCorpo, listBoxAmbulatori.SelectedIndex,listBoxPartiCorpo.SelectedIndex,listViewEsami);
            }
        }
        private void ButtonVediTutto_Click(object sender, EventArgs e)      //show all Esami
        {
            LogicSearch.SearchAll(listViewEsami, listBoxAmbulatori,listBoxPartiCorpo);
        }
    }
}
    

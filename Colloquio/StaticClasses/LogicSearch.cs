using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Colloquio
{
    public static class LogicSearch         //logic and algorithms for searching
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;

        public static DataSet dsAmbulatori = new DataSet();
        public static DataSet dsPartiCorpo = new DataSet();
        public static DataSet dsEsami = new DataSet();

        public static string TypeSearch(int indexTypeSearch)     //get type of search from comboBox
        {
            string columnOfSearch = "";
            if (indexTypeSearch == 0)
            {
                columnOfSearch = "nomeEsame";
            }
            else if (indexTypeSearch == 1)
            {
                columnOfSearch = "codiceMinisteriale";
            }
            else if (indexTypeSearch == 2)
            {
                columnOfSearch = "codiceInterno";
            }
            else if (indexTypeSearch == 3)
            {
                columnOfSearch = "descrizione";
            }
            else if (indexTypeSearch == 4)
            {
                columnOfSearch = "tutto";
            }
            return columnOfSearch;
        }
        public static void AddItemsToListFromDatabase(ListBox listBox, DataSet ds)    // function that retrives data from database
        {                                                                   //listbox of destination (Ambulatori, PartiCorpo, Esami)
            foreach (DataRow item in ds.Tables[0].Rows)                     //dataset are tables from the database
            {
                ListViewItem item1 = new ListViewItem(item[1].ToString()); // loop through all data and get the index 1 (names)

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    item1.SubItems.Add(item[i].ToString());
                }
                listBox.Items.Add(item1.Text);
            }
        }
        public static string ExecuteQueryExam(string query, ListView listViewEsami)       //execute query from database depending on the combobox selector
        {
            listViewEsami.Items.Clear();            //clear and refresh listview every new search
            listViewEsami.Refresh();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())   //get all data from tables
                    {
                        adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dsEsami, "esami"); //fill dataSet

                        sda.Fill(dt);
                        string value = dt.Rows[0].ItemArray[1].ToString(); // get element 1 from row item
                        AddItemsToListFromDatabaseEsami(dsEsami, listViewEsami);      //fill the list
                        return value;                           //return the element found
                    }
                }
            }
        }
        public static void SearchByIndexes(int indexAmbulatorio, int indexParteCorpo, ListView listViewEsami)      //selecting ambulatori and partiCorpo new search
        {
            try
            {
               /*string queryEsame = "SELECT E.[idEsame], E.[nomeEsame], E.[codiceMinisteriale], E.[codiceInterno], E.[descrizione] " +
                    "FROM[ambulatori] AS A " +
                    "INNER JOIN[partiCorpo] AS P ON A.[idParteCorpo] = P.[idParteCorpo] " +
                    "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] " +                            one to one relationship between ambulatori and partiCorpo
                    "WHERE A.[idAmbulatorio] = " + indexAmbulatorio + " AND P.[idParteCorpo] = " + indexParteCorpo + ";";
               */
                string queryEsame = "SELECT E.[idEsame], E.[nomeEsame], E.[codiceMinisteriale], E.[codiceInterno], E.[descrizione] " +      //many to many relationship
                    "FROM[ambulatori] AS A " +
                    "INNER JOIN[ambulatoriPartiCorpo] AS AP ON AP.[idAmbulatorio] = A.[idAmbulatorio] " +
                    "INNER JOIN[partiCorpo] AS P ON P.[idParteCorpo] = AP.[idParteCorpo] " +
                    "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] " +
                    "WHERE A.[idAmbulatorio] = " + indexAmbulatorio + " AND P.[idParteCorpo] = " + indexParteCorpo + ";";
                Debug.WriteLine(indexAmbulatorio);
                Debug.WriteLine(indexParteCorpo);
                ExecuteQueryExam(queryEsame, listViewEsami);
            }
            catch (Exception)
            {
                Debug.WriteLine("Esame not found, empty");
            }
            dsEsami.Clear(); //clear esami listview
        }
        public static void SearchAll(ListView listViewEsami, ListBox listBoxAmbulatori, ListBox listBoxPartiCorpo)
        {
            string queryEsame = "SELECT E.[idEsame], E.[nomeEsame], E.[codiceMinisteriale], E.[codiceInterno], E.[descrizione] FROM[ambulatori] AS A INNER JOIN[partiCorpo] AS P ON A.[idParteCorpo] = P.[idParteCorpo] INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame];";
            ExecuteQueryExam(queryEsame, listViewEsami);
            listBoxAmbulatori.SelectedIndex = -1;
            listBoxPartiCorpo.SelectedIndex = -1;
            dsEsami.Clear(); //clear esami listview
        }
        public static void SearchByBox(string valueToSearch, int indexComboBox, ListView listViewEsami, ListBox listBoxAmbulatori, ListBox listBoxPartiCorpo)       // seach exam on database
        {
            //get value from Cerca box
            if (indexComboBox == -1)
            {
                MessageBox.Show("Seleziona il tipo di ricerca");
                return;
            }
            if (valueToSearch == "" || valueToSearch == "Scrivi qui")
            {
                MessageBox.Show("Il box di ricerca e' vuoto");
                return;
            }
            try
            {
                conn = DbConnection.DbConnect();// "+ typeOfSearch + "] LIKE '%" + valueToSearch + "%'";
                string columnOfSearch = "";
                string valueFetchedEsame = "";
                string queryAmbulatorio = "";
                string queryParteCorpo = "";
                columnOfSearch = TypeSearch(indexComboBox);

                if (indexComboBox == 4) //if selected Tutto
                {
                    string queryEsame = "SELECT E.[idEsame], E.[nomeEsame], E.[codiceMinisteriale], E.[codiceInterno], E.[descrizione] " +
                        "FROM[ambulatori] AS A " +
                        "INNER JOIN[partiCorpo] AS P ON A.[idParteCorpo] = P.[idParteCorpo] " +
                        "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] WHERE E.[nomeEsame] LIKE '%" + valueToSearch + "%' " +
                        "OR E.[codiceMinisteriale] LIKE '%" + valueToSearch + "%' " +
                        "OR  E.[codiceInterno] LIKE '%" + valueToSearch + "%' " +
                        "OR E.[descrizione] LIKE '%" + valueToSearch + "%'";
                    queryAmbulatorio = "SELECT A.[nomeAmbulatorio] " +
                        "FROM[ambulatori] AS A " +
                        "INNER JOIN[partiCorpo] AS P ON A.[idParteCorpo] = P.[idParteCorpo] " +
                        "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] " +
                        "WHERE E.[nomeEsame] LIKE '%" + valueToSearch + "%' OR E.[codiceMinisteriale] LIKE '%" + valueToSearch + "%' " +
                        "OR  E.[codiceInterno] LIKE '%" + valueToSearch + "%' OR E.[descrizione] LIKE '%" + valueToSearch + "%'";
                    queryParteCorpo = "SELECT P.[parteCorpo] " +
                        "FROM[partiCorpo] AS " +
                        "P INNER JOIN[ambulatori] AS A ON A.[idParteCorpo] = P.[idParteCorpo] " +
                        "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] " +
                        "WHERE E.[nomeEsame] LIKE '%" + valueToSearch + "%' " +
                        "OR E.[codiceMinisteriale] LIKE '%" + valueToSearch + "%' " +
                        "OR  E.[codiceInterno] LIKE '%" + valueToSearch + "%' " +
                        "OR E.[descrizione] LIKE '%" + valueToSearch + "%'";
                    valueFetchedEsame = ExecuteQueryExam(queryEsame, listViewEsami);
                }
                else           //if selected anything else
                {
                    string queryEsame = "SELECT E.[idEsame], E.[nomeEsame], E.[codiceMinisteriale], E.[codiceInterno], E.[descrizione] " +
                        "FROM[ambulatori] AS A " +
                        "INNER JOIN[partiCorpo] AS P ON A.[idParteCorpo] = P.[idParteCorpo] " +
                        "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] WHERE E.[" + columnOfSearch + "] LIKE '%" + valueToSearch + "%'";
                    queryAmbulatorio = "SELECT A.[nomeAmbulatorio] FROM[ambulatori] AS A " +
                        "INNER JOIN[partiCorpo] AS P ON A.[idParteCorpo] = P.[idParteCorpo] " +
                        "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] WHERE E.[" + columnOfSearch + "] LIKE '%" + valueToSearch + "%'";
                    queryParteCorpo = "SELECT P.[parteCorpo] FROM[partiCorpo] AS P " +
                        "INNER JOIN[ambulatori] AS A ON A.[idParteCorpo] = P.[idParteCorpo] " +
                        "INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] WHERE E.[" + columnOfSearch + "] LIKE '%" + valueToSearch + "%'";
                    valueFetchedEsame = ExecuteQueryExam(queryEsame, listViewEsami);
                }
                string valueFetchedAmbulatorio = ExecuteQueryAmbulatorioParteCorpo(queryAmbulatorio);
                string valueFetchedParteCorpo = ExecuteQueryAmbulatorioParteCorpo(queryParteCorpo);
                //  ExamLookUpAndSelect(valueFetchedEsame);
                AmbulatorioANDParteLookUpAndSelect(valueFetchedAmbulatorio, listBoxAmbulatori);
                AmbulatorioANDParteLookUpAndSelect(valueFetchedParteCorpo, listBoxPartiCorpo);
                conn.Close();
                dsEsami.Clear(); //clear esami listview
            }
            catch (Exception)
            {
                MessageBox.Show("Ricerca non a buon fine");
            }
        }
        public static void AmbulatorioANDParteLookUpAndSelect(string valueFetched, ListBox listBox)        //lookUp index and highlight the items if found
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i].ToString().ToLower() == valueFetched.ToLower())    //if value found, select the exam and break the loop
                {
                    listBox.SetSelected(i, true);
                    return;
                }
            }
        }
        public static void LoadColumnEsami(ListView listView)     //create table with columns Esami
        {
            listView.View = View.Details;      //set gridlines
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.AllowColumnReorder = true;
            listView.Columns.Add("", 0);      //set headers, first value null
            listView.Columns.Add("Nome", 80);
            listView.Columns.Add("CodiceMinisteriale", 90);
            listView.Columns.Add("CodiceInterno", 80);
            listView.Columns.Add("Descrizione", 100);
        }
        public static string ExecuteQueryAmbulatorioParteCorpo(string query)       //execute query from database depending on the combobox selector
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        string value = dt.Rows[0].ItemArray[0].ToString();   //fetch element from Esami table

                        return value;
                    }
                }
            }
        }
        public static void AddItemsToListFromDatabaseEsami(DataSet ds, ListView listViewEsami)    // function that retrives data esami table
        {
            foreach (DataRow item in ds.Tables[0].Rows)                     //dataset are tables from the database
            {
                ListViewItem item1 = new ListViewItem();  // loop through all data form index 1 (names)
                for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
                {
                    item1.SubItems.Add(item[i].ToString());
                }
                listViewEsami.Items.Add(item1);     //add items to listViewEsami
            }
        }
        public static void LoadDatasetFromDatabase(string section, DataSet ds)
        {
            conn = DbConnection.DbConnect();
            string selectQuery = "select * from " + section;      //get all data from tables
            cmd = new SqlCommand(selectQuery, conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, section);
        }
        public static (int, int) GetAbmulatorioANDPartiCorpoSelected(ListBox listBoxAmbulatori, ListBox listBoxPartiCorpo) //get indexes from lists as value
        {
            return (listBoxAmbulatori.SelectedIndex, listBoxPartiCorpo.SelectedIndex);
        }
        public static void AddItemToEsamiAggiunti(ListView listViewEsami, ListView listViewEsamiAggiunti)
        {
            if (listViewEsami.SelectedItems.Count > 0)  //if exam selected add it to the list
            {
                ListViewItem item = new ListViewItem("", 0);
                for (int i = 1; i < listViewEsami.Columns.Count; i++)
                {
                    item.SubItems.Add(listViewEsami.SelectedItems[0].SubItems[i]);
                }
                listViewEsamiAggiunti.Items.Add(item);
            }
            else                                    //if not selected print a message
            {
                MessageBox.Show("Nessun esame selezionato");
            }
        }
        public static void RemoveEsamiAggiunti(ListView listViewEsamiAggiunti)
        {
            try
            {
                if (listViewEsamiAggiunti.Items.Count > 0)     //if esame selected
                {

                    listViewEsamiAggiunti.Items.RemoveAt(listViewEsamiAggiunti.SelectedItems[0].Index);
                }
                else                 //if list is empty
                {
                    MessageBox.Show("Nessun esame in lista");
                }
            }
            catch (Exception)        //if exam not selected
            {
                MessageBox.Show("Nessun esame selezionato");
            }
        }
    }
}

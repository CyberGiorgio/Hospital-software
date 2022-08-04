using Xunit;
using Colloquio;
using System.Windows.Forms;
using System.Data;

namespace ColloquioUnitTest
{
    public class UnitTest
    {
        [Theory]
        [InlineData(0)]
        public void TypeOfSearch_columns_true(int indexTypeSearch)      // type of search check
        {
            int i = indexTypeSearch;
            string[] coulmns = new string[] { "nomeEsame", "codiceMinisteriale", "codiceInterno", "descrizione" };
            for (i = 0; i < coulmns.Length; i++)
            {
                Assert.Equal(coulmns[i], LogicSearch.TypeSearch(i));
            }
        }
        [Fact]
        public void AddItemToListBox_NewItem_True()         //add aitem from DataSet to ListBox
        {
            ListBox listBox = new ListBox();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("MyTable");
            dt.Columns.Add(new DataColumn("id", typeof(int)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            DataRow dr = dt.NewRow();
            dr["id"] = 123;
            dr["name"] = "Test";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            LogicSearch.AddItemsToListFromDatabase(listBox, ds); // function that retrives data from database
            Assert.True(listBox.Items.Count == 1);
        }
        [Fact]
        public void CheckColumnsTable_EqualsToFive_True()       //check number of columns
        {
            ListView listView = new ListView();
            Assert.True(listView.Columns.Count == 0);
            listView.View = View.Details;      //set gridlines
            listView.GridLines = true;
            listView.Columns.Add("", 0);      //set headers, first value null
            listView.Columns.Add("Nome", 80);
            listView.Columns.Add("CodiceMinisteriale", 90);
            listView.Columns.Add("CodiceInterno", 80);
            listView.Columns.Add("Descrizione", 100);
            Assert.True(listView.Columns.Count == 5);
        }
        [Fact]
        public void AddItemFromListToList_PlusOne_True()        //check item added from listview to listview
        {
            ListView listViewEsami =new ListView();
            listViewEsami.Items.Add("item1");
            ListView listViewEsamiAggiunti = new ListView();
            if (listViewEsami.Items.Count > 0)  //if exam selected add it to the list
            {
                ListViewItem item = new ListViewItem("", 0);
                for (int i = 1; i < listViewEsami.Columns.Count; i++)
                {
                    item.SubItems.Add(listViewEsami.Items[i].ToString());
                }
                listViewEsamiAggiunti.Items.Add(item);
                Assert.True(listViewEsamiAggiunti.Items.Count == 1);
            }
            else                                    //if not selected print a message
            {
                MessageBox.Show("Nessun esame selezionato");
            }
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;

namespace DemoListview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupListView();
        }

        private void SetupListView()
        {
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.Columns.Add("STT", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 200, HorizontalAlignment.Left);
        }

        private void AddEmployee(int stt, string id, string name)
        {
            string[] row = { stt.ToString(), id, name };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void EditEmployee(int index, int stt, string id, string name)
        {
            if (index >= 0 && index < listView1.Items.Count)
            {
                listView1.Items[index].SubItems[0].Text = stt.ToString();
                listView1.Items[index].SubItems[1].Text = id;
                listView1.Items[index].SubItems[2].Text = name;
            }
        }

        private void RemoveEmployee(int index)
        {
            if (index >= 0 && index < listView1.Items.Count)
            {
                listView1.Items.RemoveAt(index);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int stt = int.Parse(textBoxSTT.Text);
            string id = textBoxID.Text;
            string name = textBoxName.Text;
            AddEmployee(stt, id, name);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.CheckedItems;
            if (checkedItems.Count > 0)
            {
                int index = checkedItems[0].Index;
                int stt = int.Parse(textBoxSTT.Text);
                string id = textBoxID.Text;
                string name = textBoxName.Text;
                EditEmployee(index, stt, id, name);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.CheckedItems;
            if (checkedItems.Count > 0)
            {
                int index = checkedItems[0].Index;
                RemoveEmployee(index);
            }
        }
    }
}

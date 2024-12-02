using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demoBt
{
    public partial class Form2 : Form
    {
        public string EmployeeID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public decimal EmployeeSalary
        {
            get { return decimal.Parse(txtSalary.Text); }
            set { txtSalary.Text = value.ToString(); }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

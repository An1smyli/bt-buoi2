using System;
using System.Windows.Forms;

namespace demoBt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (Form2 employeeForm = new Form2())
            {
                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells["colMSNV"].Value = employeeForm.EmployeeID;
                    dataGridView1.Rows[rowIndex].Cells["colName"].Value = employeeForm.EmployeeName;
                    dataGridView1.Rows[rowIndex].Cells["colSalary"].Value = employeeForm.EmployeeSalary;

                    // Chuyển trỏ chuột đến hàng vừa thêm
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[rowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                using (Form2 employeeForm = new Form2())
                {
                    employeeForm.EmployeeID = row.Cells["colMSNV"].Value.ToString();
                    employeeForm.EmployeeName = row.Cells["colName"].Value.ToString();
                    employeeForm.EmployeeSalary = Convert.ToDecimal(row.Cells["colSalary"].Value);

                    if (employeeForm.ShowDialog() == DialogResult.OK)
                    {
                        row.Cells["colMSNV"].Value = employeeForm.EmployeeID;
                        row.Cells["colName"].Value = employeeForm.EmployeeName;
                        row.Cells["colSalary"].Value = employeeForm.EmployeeSalary;

                        // Chuyển trỏ chuột đến hàng vừa sửa
                        dataGridView1.ClearSelection();
                        row.Selected = true;
                        dataGridView1.CurrentCell = row.Cells[0];
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Chuyển trỏ chuột đến hàng kế tiếp hoặc hàng trước đó sau khi xóa
                if (dataGridView1.Rows.Count > 0)
                {
                    rowIndex = rowIndex >= dataGridView1.Rows.Count ? dataGridView1.Rows.Count - 1 : rowIndex;
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[rowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

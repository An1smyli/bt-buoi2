using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winformSQL.Models;

namespace winformSQL
{
    public partial class Form1 : Form
    {
        ModelSV context = new ModelSV();
        public Form1()
        {
            InitializeComponent();
            this.dgvSv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSv_CellClick);
        }

        private void dgvSv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSv.Rows[e.RowIndex];
                txtMSSV.Text = row.Cells[0].Value?.ToString();
                txtNAME.Text = row.Cells[1].Value?.ToString();
                txtDTB.Text = row.Cells[3].Value?.ToString();

                string khoa = row.Cells[2].Value?.ToString();
                cbbKHOA.SelectedIndex = cbbKHOA.FindStringExact(khoa);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Faculty> listFac = context.Faculties.ToList();
                List<Student> listStu = context.Students.ToList();
                FillCbb(listFac);
                BindGrid(listStu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<Student> listStu)
        {
            dgvSv.Rows.Clear();
            foreach (var item in listStu)
            {
                int index = dgvSv.Rows.Add();
                dgvSv.Rows[index].Cells[0].Value = item.StudentID;
                dgvSv.Rows[index].Cells[1].Value = item.Name;
                dgvSv.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvSv.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void FillCbb(List<Faculty> listFac)
        {
            this.cbbKHOA.DataSource = listFac;
            this.cbbKHOA.DisplayMember = "FacultyName";
            this.cbbKHOA.ValueMember = "FacultyID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string mssv = txtMSSV.Text.Trim();
                string name = txtNAME.Text.Trim();
                string khoa = cbbKHOA.SelectedValue?.ToString();
                double dtb;

                if (!double.TryParse(txtDTB.Text.Trim(), out dtb))
                {
                    MessageBox.Show("Điểm trung bình không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(khoa))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int index = dgvSv.Rows.Add();
                dgvSv.Rows[index].Cells[0].Value = mssv;
                dgvSv.Rows[index].Cells[1].Value = name;
                dgvSv.Rows[index].Cells[2].Value = khoa;
                dgvSv.Rows[index].Cells[3].Value = dtb;

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMSSV.Clear();
                txtNAME.Clear();
                txtDTB.Clear();
                cbbKHOA.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string mssv = txtMSSV.Text.Trim();
                string name = txtNAME.Text.Trim();
                string khoa = cbbKHOA.SelectedValue?.ToString();
                double dtb;

                if (!double.TryParse(txtDTB.Text.Trim(), out dtb))
                {
                    MessageBox.Show("Điểm trung bình không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(khoa))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool studentFound = false;
                foreach (DataGridViewRow row in dgvSv.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == mssv)
                    {
                        row.Cells[1].Value = name;
                        row.Cells[2].Value = khoa;
                        row.Cells[3].Value = dtb;
                        studentFound = true;
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                if (!studentFound)
                {
                    MessageBox.Show("Không tìm thấy sinh viên với MSSV này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string mssv = txtMSSV.Text.Trim();

                if (string.IsNullOrEmpty(mssv))
                {
                    MessageBox.Show("Vui lòng nhập MSSV!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool studentFound = false;
                foreach (DataGridViewRow row in dgvSv.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == mssv)
                    {
                        dgvSv.Rows.Remove(row);
                        studentFound = true;
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                if (!studentFound)
                {
                    MessageBox.Show("Không tìm thấy sinh viên với MSSV này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
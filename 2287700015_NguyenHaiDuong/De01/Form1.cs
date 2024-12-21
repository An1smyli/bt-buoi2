using De01.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De01
{
    public partial class Form1 : Form
    {
        ModelSV context = new ModelSV();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Lop> listLop = context.Lops.ToList();
                List<SinhVien> listSV = context.SinhViens.ToList();
                FillCbb(listLop);
                BindGrid(listSV);
                btnNotsave.Enabled = false;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<SinhVien> listSV)
        {
            dgvSV.Rows.Clear();
            foreach (var item in listSV)
            {
                int index = dgvSV.Rows.Add();
                dgvSV.Rows[index].Cells[0].Value = item.MaSV;
                dgvSV.Rows[index].Cells[1].Value = item.HotenSV;
                dgvSV.Rows[index].Cells[2].Value = item.NgaySinh.ToString("dd/MM/yyyy");
                dgvSV.Rows[index].Cells[3].Value = item.Lop.TenLop;
            }
        }

        private void FillCbb(List<Lop> listLop)
        {
            this.cbbLOP.DataSource = listLop;
            this.cbbLOP.DisplayMember = "TenLop";
            this.cbbLOP.ValueMember = "MaLop";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string mssv = txtMSSV.Text.Trim();
                string name = txtNAME.Text.Trim();
                string lop = cbbLOP.SelectedValue?.ToString();
                DateTime ngaySinh = dtpNS.Value;

                if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lop))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int index = dgvSV.Rows.Add();
                dgvSV.Rows[index].Cells[0].Value = mssv;
                dgvSV.Rows[index].Cells[1].Value = name;
                dgvSV.Rows[index].Cells[2].Value = ngaySinh.ToString("dd/MM/yyyy");
                dgvSV.Rows[index].Cells[3].Value = lop;

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMSSV.Clear();
                txtNAME.Clear();
                cbbLOP.SelectedIndex = 0;
                btnNotsave.Enabled = true;
                UpdateSaveButtonState();
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
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == mssv)
                    {
                        dgvSV.Rows.Remove(row);
                        studentFound = true;
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                if (!studentFound)
                {
                    MessageBox.Show("Không tìm thấy sinh viên với MSSV này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtMSSV.Clear();
                txtNAME.Clear();
                cbbLOP.SelectedIndex = 0;
                btnNotsave.Enabled = true;
                UpdateSaveButtonState();
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
                string lop = cbbLOP.SelectedValue?.ToString();
                DateTime ngaySinh = dtpNS.Value;

                if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lop))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool studentFound = false;
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == mssv)
                    {
                        row.Cells[1].Value = name; 
                        row.Cells[3].Value = lop; 
                        row.Cells[2].Value = ngaySinh.ToString("dd/MM/yyyy");
                        studentFound = true;
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                if (!studentFound)
                {
                    MessageBox.Show("Không tìm thấy sinh viên với MSSV này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtMSSV.Clear();
                txtNAME.Clear();
                cbbLOP.SelectedIndex = 0;
                btnNotsave.Enabled = true;
                UpdateSaveButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    if (row.IsNewRow) continue;

                    string mssv = row.Cells[0].Value?.ToString();
                    string name = row.Cells[1].Value?.ToString();
                    string lopId = row.Cells[3].Value?.ToString();
                    string ngaySinhStr = row.Cells[2].Value?.ToString();

                    if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lopId) || string.IsNullOrEmpty(ngaySinhStr))
                    {
                        continue; 
                    }

                    if (!DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaySinh))
                    {
                        MessageBox.Show($"Ngày sinh không hợp lệ ở dòng {row.Index + 1}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var existingStudent = context.SinhViens.SingleOrDefault(s => s.MaSV == mssv);
                    if (existingStudent != null)
                    {
                        existingStudent.HotenSV = name;
                        existingStudent.MaLop = lopId;
                        existingStudent.NgaySinh = ngaySinh;
                    }
                    else
                    {
                        var newStudent = new SinhVien
                        {
                            MaSV = mssv,
                            HotenSV = name,
                            MaLop = lopId,
                            NgaySinh = ngaySinh
                        };
                        context.SinhViens.Add(newStudent);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNotsave.Enabled = true;
                UpdateSaveButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSaveButtonState()
        {
            btnSave.Enabled = dgvSV.Rows.Cast<DataGridViewRow>().Any(row => !row.IsNewRow);
        }

        private void btnNotsave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;

                btnNotsave.Enabled = false;

                MessageBox.Show("Đã tắt chức năng lưu và huỷ lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSEARCH_Click(object sender, EventArgs e)
        {
            try
            {

                string searchQuery = txtSEARCH.Text.Trim();

                if (string.IsNullOrEmpty(searchQuery))
                {
                    List<SinhVien> listSV = context.SinhViens.ToList();
                    BindGrid(listSV); 
                }
                else
                {
                    List<SinhVien> searchResults = context.SinhViens
                        .Where(sv => sv.HotenSV.ToLower().Contains(searchQuery.ToLower())) 
                        .ToList();

                    BindGrid(searchResults); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnX_Click(object sender, EventArgs e)
        {
            txtSEARCH.Clear();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSV.Rows[e.RowIndex];

                var mssv = row.Cells[0].Value?.ToString(); 
                var name = row.Cells[1].Value?.ToString(); 
                var ngaySinhStr = row.Cells[2].Value?.ToString(); 
                var lop = row.Cells[3].Value?.ToString(); 

                txtMSSV.Text = mssv;
                txtNAME.Text = name;

                if (DateTime.TryParse(ngaySinhStr, out DateTime ngaySinh))
                {
                    dtpNS.Value = ngaySinh;
                }

                cbbLOP.SelectedIndex = cbbLOP.FindStringExact(lop);
            }
        }
    }
}
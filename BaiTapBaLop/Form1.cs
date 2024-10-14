using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapBaLop
{
    public partial class Form1 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dataGridView1);
                var Faculties = facultyService.GetAll();
                var Students = studentService.GetAll();
                FillFacultyComboBox(Faculties);
                BindGrid(Students);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        private void FillFacultyComboBox(List<Faculty> faculties)
        {
            //faculties.Insert(0, new Faculty());
            cmbKhoa.DataSource = faculties;
            cmbKhoa.DisplayMember = "FacultyName";
            cmbKhoa.ValueMember = "FacultyID";
        }
        private void BindGrid(List<Student> students)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in students)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.StudentID;
                dataGridView1.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                {
                    dataGridView1.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                    dataGridView1.Rows[index].Cells[3].Value = item.AverageScore + "";
                }
                if (item.MajorID != null)
                {
                    dataGridView1.Rows[index].Cells[4].Value = item.Major.Name + "";
                    //ShowAvatar(item.Avatar);
                }
            }
        }
        //private void ShowAvatar(string ImageName)
        //{
        //    if (string.IsNullOrEmpty(ImageName))
        //    {
        //        pictureBox1.Image = null;
        //    }
        //    else
        //    {
        //        string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        //        string imagePath = Path.Combine(parentDirectory, "Images",ImageName);
        //        pictureBox1.Image = Image.FromFile(imagePath);
        //        pictureBox1.Refresh();
        //    }
        //}
        public void setGridViewStyle(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.BackgroundColor = Color.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadData()
        {
            List<Student> students = studentService.GetAll();
            BindGrid(students);
        }
        private void ResetInput()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            cmbKhoa.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var Students = new List<Student>();
            if (checkBox1.Checked)
                Students = studentService.GetAllHasNoMajor();
            else
                Students = studentService.GetAll();
            BindGrid(Students);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMSSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtDiemTB.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                if (txtMSSV.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải có 10 kí tự!");
                    return;
                }

                if (!float.TryParse(txtDiemTB.Text.Trim(), out float avgScore) || avgScore < 0 || avgScore > 10)
                {
                    MessageBox.Show("Điểm trung bình phải nằm trong khoảng từ 0 đến 10!");
                    return;
                }

                Student newStudent = new Student
                {
                    StudentID = txtMSSV.Text.Trim(),
                    FullName = txtHoTen.Text.Trim(),
                    AverageScore = avgScore,
                    FacultyID = Convert.ToInt32(cmbKhoa.SelectedValue),
                };
                studentService.InsertUpdate(newStudent);
                MessageBox.Show("Thêm mới dữ liệu thành công!");
                LoadData();
                ResetInput();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMSSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtDiemTB.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                if (txtMSSV.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải có 10 kí tự!");
                    return;
                }

                if (!float.TryParse(txtDiemTB.Text.Trim(), out float avgScore) || avgScore < 0 || avgScore > 10)
                {
                    MessageBox.Show("Điểm trung bình phải nằm trong khoảng từ 0 đến 10!");
                    return;
                }

                string studentID = txtMSSV.Text.Trim();
                Student eStudent = studentService.FindById(studentID);
                if (eStudent != null)
                {
                    eStudent.FullName = txtHoTen.Text.Trim();
                    eStudent.AverageScore = avgScore;
                    eStudent.FacultyID = Convert.ToInt32(cmbKhoa.SelectedValue);
                    studentService.InsertUpdate(eStudent);
                    MessageBox.Show("Cập nhật dữ liệu thành công");
                    LoadData();
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần sửa!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                    txtMSSV.Text = row.Cells[0].Value?.ToString();
                    txtHoTen.Text = row.Cells[1].Value?.ToString();
                    txtDiemTB.Text = row.Cells[3].Value?.ToString();

                    string facultyName = row.Cells[2].Value?.ToString();
                    var faculty = facultyService.FindByName(facultyName);

                    if (faculty != null)
                    {
                        cmbKhoa.SelectedValue = faculty.FacultyID;
                    }
                    else
                    {
                        cmbKhoa.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát", "Đồng ý thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

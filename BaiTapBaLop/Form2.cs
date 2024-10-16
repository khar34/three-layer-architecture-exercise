using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL.Entities;

namespace BaiTapBaLop
{
    public partial class Form2 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                var listFaculties = facultyService.GetAll();
                FillFacultyComboBox(listFaculties);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FillFacultyComboBox(List<Faculty> facultyList)
        {
            cmbKhoa.DataSource = facultyList;
            cmbKhoa.DisplayMember = "FacultyName";
            cmbKhoa.ValueMember = "FacultyID";
        }

        private void FillMajorComboBox(List<Major> majorList)
        {
            cmbNganh.DataSource = majorList;
            cmbNganh.DisplayMember = "Name";
            cmbNganh.ValueMember = "MajorID";
        }

        private void BindGrid(List<Student> studentList)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in studentList)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[1].Value = item.StudentID;
                dataGridView1.Rows[index].Cells[2].Value = item.FullName;
                if (item.Faculty != null)
                    dataGridView1.Rows[index].Cells[3].Value = item.Faculty.FacultyName;
                dataGridView1.Rows[index].Cells[4].Value = item.AverageScore + "";
                if (item.MajorID != null)
                    dataGridView1.Rows[index].Cells[5].Value = item.Major.Name + "";

            }
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty selectedFaculty = cmbKhoa.SelectedItem as Faculty;
            if (selectedFaculty != null)
            {
                var listMajors = MajorService.GetAllByFaculty(selectedFaculty.FacultyID);
                FillMajorComboBox(listMajors);
                var listStudents = StudentService.GetAllHasNoMajor(selectedFaculty.FacultyID);
                BindGrid(listStudents);
            }
        }

        

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            try
            {
                Major selectedMajor = cmbNganh.SelectedItem as Major;
                if (selectedMajor == null)
                {
                    MessageBox.Show("Vui lòng chọn ngành để đăng ký!");
                    return;
                }

                List<Student> selectedStudents = new List<Student>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                    if (isChecked)
                    {
                        string studentID = row.Cells[1].Value.ToString();
                        Student student = StudentService.FindById(studentID);
                        if (student != null)
                        {
                            student.MajorID = selectedMajor.MajorID;  
                            selectedStudents.Add(student);  
                        }
                    }
                }

                if (selectedStudents.Count > 0)
                {
                    foreach (var student in selectedStudents)
                    {
                        StudentService.InsertUpdate(student);  
                    }

                    MessageBox.Show("Đăng ký ngành thành công!");
                    var listStudents = StudentService.GetAllHasNoMajor((int)cmbKhoa.SelectedValue);
                    BindGrid(listStudents);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sinh viên để đăng ký!");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        
    }
}

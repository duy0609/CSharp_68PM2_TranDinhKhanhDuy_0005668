using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSharp_68PM2_TranDinhKhanhDuy_0005668
{
    public partial class UC_QLSV : UserControl
    {
        public UC_QLSV()
        {
            InitializeComponent();
            SetupStudentGrid();
            SetupFormDefaults();
            LoadClasses();
            LoadStudents();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SetupStudentGrid()
        {
            dataGridView1.AutoGenerateColumns = false;

            MSSV.DataPropertyName = "MSSV";
            Column1.DataPropertyName = "FullName";
            Column2.DataPropertyName = "Gender";
            Column3.DataPropertyName = "DateOfBirth";
            Column4.DataPropertyName = "ClassName";
        }

        private void SetupFormDefaults()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Nam");
            comboBox2.Items.Add("Nữ");
            comboBox2.SelectedIndex = 0;
        }

        private void LoadClasses()
        {
            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                using MySqlDataAdapter adapter = new MySqlDataAdapter(
                    "SELECT ClassId, ClassName FROM Classes ORDER BY ClassName",
                    connection);

                DataTable classes = new DataTable();
                adapter.Fill(classes);

                comboBox3.DisplayMember = "ClassName";
                comboBox3.ValueMember = "ClassId";
                comboBox3.DataSource = classes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách lớp: " + ex.Message);
            }
        }

        private void LoadStudents()
        {
            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                using MySqlDataAdapter adapter = new MySqlDataAdapter(
                    @"SELECT s.MSSV,
                             s.FullName,
                             s.Gender,
                             DATE_FORMAT(s.DateOfBirth, '%Y-%m-%d') AS DateOfBirth,
                             c.ClassName
                      FROM Students s
                      INNER JOIN Classes c ON c.ClassId = s.ClassId
                      ORDER BY s.MSSV",
                    connection);

                DataTable students = new DataTable();
                adapter.Fill(students);

                dataGridView1.DataSource = students;
                label4.Text = $"Trang 1/1 | {students.Rows.Count} bản ghi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sinh viên: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_mssv.Text) || string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV và họ tên.");
                return;
            }

            if (comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                return;
            }

            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                connection.Open();

                using MySqlCommand command = new MySqlCommand(
                    @"INSERT INTO Students (MSSV, FullName, Gender, DateOfBirth, ClassId)
                      VALUES (@MSSV, @FullName, @Gender, @DateOfBirth, @ClassId)",
                    connection);

                command.Parameters.AddWithValue("@MSSV", txt_mssv.Text.Trim());
                command.Parameters.AddWithValue("@FullName", txt_name.Text.Trim());
                command.Parameters.AddWithValue("@Gender", comboBox2.Text);
                command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker2.Value.Date);
                command.Parameters.AddWithValue("@ClassId", comboBox3.SelectedValue);

                command.ExecuteNonQuery();

                MessageBox.Show("Thêm sinh viên thành công.");
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được sinh viên: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}

using System.Data;
using MySql.Data.MySqlClient;

namespace CSharp_68PM2_TranDinhKhanhDuy_0005668
{
    public partial class UC_QLSV : UserControl
    {
        private const int PageSize = 10;
        private string? selectedMssv;
        private string currentKeyword = string.Empty;
        private int currentPage = 1;
        private int totalPages = 1;

        public UC_QLSV()
        {
            InitializeComponent();
            SetupStudentGrid();
            SetupFormDefaults();
            LoadClasses();
            LoadStudents();
        }

        private void SetupStudentGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            MSSV.DataPropertyName = "MSSV";
            Column1.DataPropertyName = "FullName";
            Column2.DataPropertyName = "Gender";
            Column3.DataPropertyName = "DateOfBirth";
            Column4.DataPropertyName = "ClassName";
        }

        private void SetupFormDefaults()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(["Nam", "Nữ"]);
            comboBox2.SelectedIndex = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadClasses()
        {
            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                using MySqlDataAdapter adapter = new(
                    "SELECT ClassId, ClassName FROM Classes ORDER BY ClassName",
                    connection);

                DataTable classes = new();
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
                connection.Open();

                const string filter = @"(@Keyword = ''
                    OR s.MSSV LIKE @SearchKeyword
                    OR s.FullName LIKE @SearchKeyword
                    OR c.ClassName LIKE @SearchKeyword)";

                using MySqlCommand countCommand = new(
                    $@"SELECT COUNT(*)
                       FROM Students s
                       INNER JOIN Classes c ON c.ClassId = s.ClassId
                       WHERE {filter}",
                    connection);
                AddSearchParameters(countCommand);

                int totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
                totalPages = Math.Max(1, (int)Math.Ceiling(totalRecords / (double)PageSize));
                currentPage = Math.Clamp(currentPage, 1, totalPages);

                using MySqlCommand dataCommand = new(
                    $@"SELECT s.MSSV,
                              s.FullName,
                              s.Gender,
                              DATE_FORMAT(s.DateOfBirth, '%Y-%m-%d') AS DateOfBirth,
                              c.ClassName
                       FROM Students s
                       INNER JOIN Classes c ON c.ClassId = s.ClassId
                       WHERE {filter}
                       ORDER BY s.MSSV
                       LIMIT @PageSize OFFSET @Offset",
                    connection);
                AddSearchParameters(dataCommand);
                dataCommand.Parameters.AddWithValue("@PageSize", PageSize);
                dataCommand.Parameters.AddWithValue("@Offset", (currentPage - 1) * PageSize);

                using MySqlDataAdapter adapter = new(dataCommand);
                DataTable students = new();
                adapter.Fill(students);

                dataGridView1.DataSource = students;
                label4.Text = $"Trang {currentPage}/{totalPages} | {totalRecords} bản ghi";
                UpdatePagingButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sinh viên: " + ex.Message);
            }
        }

        private void AddSearchParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@Keyword", currentKeyword);
            command.Parameters.AddWithValue("@SearchKeyword", $"%{currentKeyword}%");
        }

        private void UpdatePagingButtons()
        {
            button6.Enabled = currentPage > 1;
            button7.Enabled = currentPage > 1;
            button8.Enabled = currentPage < totalPages;
            button9.Enabled = currentPage < totalPages;
        }

        private bool ValidateStudentInput()
        {
            if (string.IsNullOrWhiteSpace(txt_mssv.Text) || string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV và họ tên.");
                return false;
            }

            if (comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                return false;
            }

            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }

            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is not DataRowView student)
            {
                return;
            }

            selectedMssv = student["MSSV"].ToString();
            txt_mssv.Text = selectedMssv;
            txt_mssv.ReadOnly = true;
            txt_name.Text = student["FullName"].ToString();
            comboBox2.Text = student["Gender"].ToString();
            comboBox3.Text = student["ClassName"].ToString();

            if (DateTime.TryParse(student["DateOfBirth"].ToString(), out DateTime dateOfBirth))
            {
                dateTimePicker2.Value = dateOfBirth;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInput())
            {
                return;
            }

            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                connection.Open();
                using MySqlCommand command = new(
                    @"INSERT INTO Students (MSSV, FullName, Gender, DateOfBirth, ClassId)
                      VALUES (@MSSV, @FullName, @Gender, @DateOfBirth, @ClassId)",
                    connection);
                AddStudentParameters(command, txt_mssv.Text.Trim());
                command.ExecuteNonQuery();

                MessageBox.Show("Thêm sinh viên thành công.");
                ClearForm();
                currentPage = 1;
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được sinh viên: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMssv))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa.");
                return;
            }

            if (!ValidateStudentInput())
            {
                return;
            }

            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                connection.Open();
                using MySqlCommand command = new(
                    @"UPDATE Students
                      SET FullName = @FullName,
                          Gender = @Gender,
                          DateOfBirth = @DateOfBirth,
                          ClassId = @ClassId
                      WHERE MSSV = @MSSV",
                    connection);
                AddStudentParameters(command, selectedMssv);
                command.ExecuteNonQuery();

                MessageBox.Show("Sửa sinh viên thành công.");
                ClearForm();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không sửa được sinh viên: " + ex.Message);
            }
        }

        private void AddStudentParameters(MySqlCommand command, string mssv)
        {
            command.Parameters.AddWithValue("@MSSV", mssv);
            command.Parameters.AddWithValue("@FullName", txt_name.Text.Trim());
            command.Parameters.AddWithValue("@Gender", comboBox2.Text);
            command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker2.Value.Date);
            command.Parameters.AddWithValue("@ClassId", comboBox3.SelectedValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMssv))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sinh viên {selectedMssv}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                connection.Open();
                using MySqlCommand command = new(
                    "DELETE FROM Students WHERE MSSV = @MSSV",
                    connection);
                command.Parameters.AddWithValue("@MSSV", selectedMssv);
                command.ExecuteNonQuery();

                MessageBox.Show("Xóa sinh viên thành công.");
                ClearForm();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được sinh viên: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentKeyword = string.Empty;
            currentPage = 1;
            textBox1.Clear();
            ClearForm();
            LoadClasses();
            LoadStudents();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentKeyword = textBox1.Text.Trim();
            currentPage = 1;
            ClearForm();
            LoadStudents();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadStudents();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadStudents();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadStudents();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadStudents();
        }

        private void ClearForm()
        {
            selectedMssv = null;
            txt_mssv.ReadOnly = false;
            txt_mssv.Clear();
            txt_name.Clear();
            comboBox2.SelectedIndex = comboBox2.Items.Count > 0 ? 0 : -1;
            comboBox3.SelectedIndex = comboBox3.Items.Count > 0 ? 0 : -1;
            dateTimePicker2.Value = DateTime.Today;
            dataGridView1.ClearSelection();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}

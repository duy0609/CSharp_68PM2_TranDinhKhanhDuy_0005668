using System.Data;
using MySql.Data.MySqlClient;

namespace CSharp_68PM2_TranDinhKhanhDuy_0005668
{
    public partial class UC_QLLH : UserControl
    {
        private const int PageSize = 10;
        private int? selectedClassId;
        private string currentKeyword = string.Empty;
        private int currentPage = 1;
        private int totalPages = 1;

        public UC_QLLH()
        {
            InitializeComponent();
            SetupClassGrid();
        }

        private void UC_QLLH_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadClasses();
        }

        private void SetupClassGrid()
        {
            dgvLopHoc.AutoGenerateColumns = false;
            dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLopHoc.MultiSelect = false;
            txtMaID.ReadOnly = true;

            colMaID.DataPropertyName = "ClassId";
            colMaLop.DataPropertyName = "ClassCode";
            colTenLop.DataPropertyName = "ClassName";
            colGhiChu.DataPropertyName = "Note";
        }

        private void LoadClasses()
        {
            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                connection.Open();

                const string filter = @"(@Keyword = ''
                    OR CAST(ClassId AS CHAR) LIKE @SearchKeyword
                    OR ClassCode LIKE @SearchKeyword
                    OR ClassName LIKE @SearchKeyword)";

                using MySqlCommand countCommand = new(
                    $"SELECT COUNT(*) FROM Classes WHERE {filter}",
                    connection);
                AddSearchParameters(countCommand);
                int totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
                totalPages = Math.Max(1, (int)Math.Ceiling(totalRecords / (double)PageSize));
                currentPage = Math.Clamp(currentPage, 1, totalPages);

                using MySqlCommand dataCommand = new(
                    $@"SELECT ClassId, ClassCode, ClassName, Note
                       FROM Classes
                       WHERE {filter}
                       ORDER BY ClassId
                       LIMIT @PageSize OFFSET @Offset",
                    connection);
                AddSearchParameters(dataCommand);
                dataCommand.Parameters.AddWithValue("@PageSize", PageSize);
                dataCommand.Parameters.AddWithValue("@Offset", (currentPage - 1) * PageSize);

                using MySqlDataAdapter adapter = new(dataCommand);
                DataTable classes = new();
                adapter.Fill(classes);
                dgvLopHoc.DataSource = classes;

                lblPhanTrang.Text = $"Trang {currentPage}/{totalPages} | {totalRecords} bản ghi";
                UpdatePagingButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách lớp: " + ex.Message);
            }
        }

        private void AddSearchParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@Keyword", currentKeyword);
            command.Parameters.AddWithValue("@SearchKeyword", $"%{currentKeyword}%");
        }

        private void UpdatePagingButtons()
        {
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;
        }

        private bool ValidateClassInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp và tên lớp.");
                return false;
            }

            return true;
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLopHoc.Rows.Count)
            {
                return;
            }

            if (dgvLopHoc.Rows[e.RowIndex].DataBoundItem is not DataRowView classRow)
            {
                return;
            }

            selectedClassId = Convert.ToInt32(classRow["ClassId"]);
            txtMaID.Text = selectedClassId.ToString();
            txtMaLop.Text = classRow["ClassCode"].ToString();
            txtTenLop.Text = classRow["ClassName"].ToString();
            txtGhiChu.Text = classRow["Note"].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateClassInput())
            {
                return;
            }

            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                connection.Open();
                using MySqlCommand command = new(
                    @"INSERT INTO Classes (ClassCode, ClassName, Note)
                      VALUES (@ClassCode, @ClassName, @Note)",
                    connection);
                AddClassParameters(command);
                command.ExecuteNonQuery();

                MessageBox.Show("Thêm lớp học thành công.");
                ClearForm();
                currentPage = 1;
                LoadClasses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được lớp học: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedClassId == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa.");
                return;
            }

            if (!ValidateClassInput())
            {
                return;
            }

            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                connection.Open();
                using MySqlCommand command = new(
                    @"UPDATE Classes
                      SET ClassCode = @ClassCode,
                          ClassName = @ClassName,
                          Note = @Note
                      WHERE ClassId = @ClassId",
                    connection);
                AddClassParameters(command);
                command.Parameters.AddWithValue("@ClassId", selectedClassId);
                command.ExecuteNonQuery();

                MessageBox.Show("Sửa lớp học thành công.");
                ClearForm();
                LoadClasses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không sửa được lớp học: " + ex.Message);
            }
        }

        private void AddClassParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@ClassCode", txtMaLop.Text.Trim());
            command.Parameters.AddWithValue("@ClassName", txtTenLop.Text.Trim());
            command.Parameters.AddWithValue("@Note", txtGhiChu.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedClassId == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa.");
                return;
            }

            if (CountStudentsInClass(selectedClassId.Value) > 0)
            {
                MessageBox.Show("Không thể xóa lớp đang có sinh viên.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa lớp {txtMaLop.Text}?",
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
                    "DELETE FROM Classes WHERE ClassId = @ClassId",
                    connection);
                command.Parameters.AddWithValue("@ClassId", selectedClassId);
                command.ExecuteNonQuery();

                MessageBox.Show("Xóa lớp học thành công.");
                ClearForm();
                LoadClasses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được lớp học: " + ex.Message);
            }
        }

        private int CountStudentsInClass(int classId)
        {
            using MySqlConnection connection = DBConnect.GetConnection();
            connection.Open();
            using MySqlCommand command = new(
                "SELECT COUNT(*) FROM Students WHERE ClassId = @ClassId",
                connection);
            command.Parameters.AddWithValue("@ClassId", classId);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            currentKeyword = string.Empty;
            currentPage = 1;
            txtTimKiem.Clear();
            ClearForm();
            LoadClasses();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            currentKeyword = txtTimKiem.Text.Trim();
            currentPage = 1;
            ClearForm();
            LoadClasses();
        }

        private void btnXemDSSV_Click(object sender, EventArgs e)
        {
            if (selectedClassId == null)
            {
                MessageBox.Show("Vui lòng chọn lớp để xem danh sách sinh viên.");
                return;
            }

            try
            {
                using MySqlConnection connection = DBConnect.GetConnection();
                using MySqlDataAdapter adapter = new(
                    @"SELECT MSSV AS 'MSSV',
                             FullName AS 'Họ và tên',
                             Gender AS 'Giới tính',
                             DATE_FORMAT(DateOfBirth, '%Y-%m-%d') AS 'Ngày sinh'
                      FROM Students
                      WHERE ClassId = @ClassId
                      ORDER BY MSSV",
                    connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ClassId", selectedClassId);

                DataTable students = new();
                adapter.Fill(students);
                ShowStudentList(students);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sinh viên: " + ex.Message);
            }
        }

        private void ShowStudentList(DataTable students)
        {
            using Form form = new()
            {
                Text = $"Sinh viên lớp {txtMaLop.Text} - {txtTenLop.Text}",
                StartPosition = FormStartPosition.CenterParent,
                Width = 850,
                Height = 500
            };
            DataGridView grid = new()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                DataSource = students
            };
            form.Controls.Add(grid);
            form.ShowDialog(this);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadClasses();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadClasses();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadClasses();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadClasses();
        }

        private void ClearForm()
        {
            selectedClassId = null;
            txtMaID.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtGhiChu.Clear();
            dgvLopHoc.ClearSelection();
        }
    }
}

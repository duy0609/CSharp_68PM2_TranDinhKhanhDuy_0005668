using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM2_TranDinhKhanhDuy_0005668
{
    public partial class Maincs : Form
    {
        // Khởi tạo null! để tắt cảnh báo CS8618
        private Panel mainPanel = null!;
        private MenuStrip menuStrip = null!;
        private ToolStripMenuItem menuStudent = null!;
        private ToolStripMenuItem menuClass = null!;

        private UC_QLSV ucStudent = null!;
        private UC_QLLH ucClass = null!;

        public Maincs()
        {
            InitializeComponent();

            TaoGiaoDienBangCode();

            ucStudent = new UC_QLSV();
            ucClass = new UC_QLLH();

            ucStudent.Dock = DockStyle.Fill;
            ucClass.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(ucStudent);
            mainPanel.Controls.Add(ucClass);

            ShowStudentManagement();
        }

        private void TaoGiaoDienBangCode()
        {
            mainPanel = new Panel();
            menuStrip = new MenuStrip();
            menuStudent = new ToolStripMenuItem("Quản lý Sinh Viên");
            menuClass = new ToolStripMenuItem("Quản lý Lớp Học");

            menuStudent.Name = "menuStudent";
            menuStudent.Click += menuStudent_Click;

            menuClass.Name = "menuClass";
            menuClass.Click += menuClass_Click;

            menuStrip.Items.Add(menuStudent);
            menuStrip.Items.Add(menuClass);

            mainPanel.Name = "mainPanel";
            mainPanel.Dock = DockStyle.Fill;

            this.Controls.Add(mainPanel);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void ShowStudentManagement()
        {
            ucStudent.BringToFront();

            // Xử lý cảnh báo CS8602
            if (menuStudent.Font != null && menuClass.Font != null)
            {
                menuStudent.Font = new Font(menuStudent.Font, FontStyle.Bold);
                menuClass.Font = new Font(menuClass.Font, FontStyle.Regular);
            }
        }

        private void ShowClassManagement()
        {
            ucClass.BringToFront();

            // Xử lý cảnh báo CS8602
            if (menuStudent.Font != null && menuClass.Font != null)
            {
                menuClass.Font = new Font(menuClass.Font, FontStyle.Bold);
                menuStudent.Font = new Font(menuStudent.Font, FontStyle.Regular);
            }
        }

        // Đổi object thành object? để tắt cảnh báo CS8622
        private void menuStudent_Click(object? sender, EventArgs e)
        {
            ShowStudentManagement();
        }

        private void menuClass_Click(object? sender, EventArgs e)
        {
            ShowClassManagement();
        }
    }
}
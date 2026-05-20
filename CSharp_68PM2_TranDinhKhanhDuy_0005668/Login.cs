using System;
using System.Windows.Forms;

namespace CSharp_68PM2_TranDinhKhanhDuy_0005668
{
    public partial class Login : Form
    {

        private const string EMAIL_SINHVIEN = "duy060905@gmail.com";
        private const string MSSV = "0005668";

        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (username == EMAIL_SINHVIEN && password == MSSV)
            {
                MessageBox.Show(
                    "Đăng nhập thành công!\nChào mừng bạn đến với hệ thống.",
                    "Đăng nhập thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
            else
            {
                MessageBox.Show(
                    "Đăng nhập thất bại!\nTên đăng nhập hoặc mật khẩu không đúng.",
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát khỏi chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
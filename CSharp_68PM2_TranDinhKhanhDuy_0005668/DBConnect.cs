using MySql.Data.MySqlClient;

namespace CSharp_68PM2_TranDinhKhanhDuy_0005668
{
    internal static class DBConnect
    {
        private const string ConnectionString =
            "Server=localhost;Port=3306;Database=QLSinhVienCSharp;Uid=root;Pwd=123456" +
            ";SslMode=Disabled;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}

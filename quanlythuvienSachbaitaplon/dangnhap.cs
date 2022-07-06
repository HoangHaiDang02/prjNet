using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace quanlythuvienSachbaitaplon
{
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            //đặt biến kết nối SQL sever
            SqlConnection conn = new SqlConnection(@"Data Source=DANGGOODBOY;Initial Catalog=quanlyDangNhap;Integrated Security=True");
            
                //mở sql sv
                conn.Open();
                //lấy tk mk từ textbox
                string tk = tbTaiKhoan.Text;
                string mk = tbMatKhau.Text;
                if(tk=="")
                {
                    MessageBox.Show("Bạn chưa nhập tài khoản","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    this.Focus();
                }
                else if (mk == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Focus();
                }
                else
                {
                    //câu lệnh truy vấn sql sv
                    string sql = "select * from NguoiDung where Taikhoan='" + tk + "' and Matkhau='" + mk + "'";
                    //thêm câu lệnh truy vấn vào sql conn
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //tạo biến đọc file SQL sau khi thêm câu lệnh truy vấn
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    //Nếu đọc file thành công thì thực hiện câu lệnh
                    if (sqlDataReader.Read())
                    {
                        //Nếu dữ liệu khớp thực hiện lệnh đăng nhập
                        MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        giaodiennew f = new giaodiennew();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        //Nếu dữ liệu sai yêu cầu nhập lại
                        MessageBox.Show("Vui lòng nhập lại tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                    }
                }
            
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            //Thoát toàn bộ chương trình
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

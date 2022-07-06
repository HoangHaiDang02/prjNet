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
    public partial class giaodiennew : Form
    {
        public giaodiennew()
        {
            InitializeComponent();
        }

        //khai báo biến kết nối sql
        SqlConnection conn = null;//khai báo báo kết nối sql
        //khai báo datatable để đổ dữ liệu vào
        DataTable dtHV;//tạo bảng datatable
        DataTable dtCD;//....
        DataTable dtSach;
        DataTable dtPM;
        DataTable dtTK;

        private void giaodiennew_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        //khai báo dòng liên kết sql
        string sqlstring = "Data Source=DANGGOODBOY;Initial Catalog=quanLyThuVien;Integrated Security=True";
        private void giaodiennew_Load(object sender, EventArgs e)
        {
            // gán biến sql và mở sql
            conn = new SqlConnection(sqlstring);
            conn.Open();


            //
            string sql = "Select * from HoiVien";
            SqlDataAdapter daHV = new SqlDataAdapter(sql, conn);
            dtHV = new DataTable();
            daHV.Fill(dtHV);
            dgvHoiVien.DataSource = dtHV;

            string sql1 = "Select * from ChuDe";
            SqlDataAdapter daCD = new SqlDataAdapter(sql1, conn);
            dtCD = new DataTable();
            daCD.Fill(dtCD);
            dgvChuDe.DataSource = dtCD;

            string sql2 = "Select * from Sach";
            SqlDataAdapter daS = new SqlDataAdapter(sql2, conn);
            dtSach = new DataTable();
            daS.Fill(dtSach);
            dgvSach.DataSource = dtSach;

            string sql3 = "Select * from PhieuMuon";
            SqlDataAdapter daPM = new SqlDataAdapter(sql3, conn);
            dtPM = new DataTable();
            daPM.Fill(dtPM);
            cbMaSach.DataSource = dtSach;
            cbMaSach.DisplayMember = "MaSach";
            cbMaHoiVien.DataSource = dtHV;
            cbMaHoiVien.DisplayMember = "MaHoiVien";
            dgvPhieuMuon.DataSource = dtPM;

            string sqlTK = "select 100-count(MaPhieuMuon) as SoLuongSachCon,MaSach from PhieuMuon group by MaSach";
            SqlDataAdapter daTK = new SqlDataAdapter(sqlTK, conn);
            dtTK = new DataTable();
            daTK.Fill(dtTK);
            dgvTK.DataSource = dtTK;
        }

        private void btThem1_Click(object sender, EventArgs e)
        {
            bool isCotain = false;
            foreach(DataRow row in dtHV.Rows)
            {
                if(row.Field<string>("MaHoiVien")==tbMaHoiVien.Text)
                {
                    isCotain = true;
                    MessageBox.Show("Mã hội viên đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                }    
            }
            if (isCotain == false)
            {
                if (tbMaHoiVien.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập mã hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
                else if (tbHoTen.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập họ tên hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
                else if (tbEmail.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập email hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
                else if (tbDiaChi.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập địa chỉ hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
                else if (tbSDT.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập số điện thoại hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
                else
                {
                    conn = new SqlConnection(sqlstring);
                    conn.Open();
                    string sqlInsert = "Insert into HoiVien values(N'" + tbMaHoiVien.Text + "',N'" + tbHoTen.Text + "',N'" + tbEmail.Text + "',N'" + tbSDT.Text + "',N'" + tbDiaChi.Text + "',N'" + dateThamGia.Value + "')";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.ExecuteNonQuery();

                    string sql = "Select * from HoiVien";
                    SqlDataAdapter daHV = new SqlDataAdapter(sql, conn);
                    dtHV = new DataTable();
                    daHV.Fill(dtHV);
                    cbMaHoiVien.DataSource = dtHV;
                    cbMaHoiVien.DisplayMember = "MaHoiVien";
                    dgvHoiVien.DataSource = dtHV;
                }
            }
        }
        private void dgvHoiVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaHoiVien.Text = dgvHoiVien.CurrentRow.Cells["MaHoiVien"].Value.ToString();
            tbHoTen.Text = dgvHoiVien.CurrentRow.Cells["HoTenHoiVien"].Value.ToString();
            tbEmail.Text = dgvHoiVien.CurrentRow.Cells["Email"].Value.ToString();
            tbSDT.Text = dgvHoiVien.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            tbDiaChi.Text = dgvHoiVien.CurrentRow.Cells["DiaChi"].Value.ToString();
        }
        string tenChuDe;
        string motaChuDe;
        private void btThem3_Click(object sender, EventArgs e)
        {
            bool isCotain = false;
            foreach(DataRow row in dtCD.Rows)
            {
                if(row.Field<string>("MaChuDe")==cbMaChuDe.Text)
                {
                    isCotain = true;
                    MessageBox.Show("Mã chủ đề đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }    
            }    
            if(isCotain==false)
            {
                switch(cbMaChuDe.Text)
                {
                    case "001":
                        tenChuDe="Lập trình";
                        motaChuDe="Học lập trình";
                        break;
                    case "002":
                        tenChuDe = "Toán học";
                        motaChuDe = "Logic và tư duy";
                        break;
                    case "003":
                        tenChuDe = "Đời sống";
                        motaChuDe = "Kiến thức xã hội thực tế";
                        break;
                    case "004":
                        tenChuDe = "Hệ thống máy tính";
                        motaChuDe = "Phân tích thiết kế hệ thống máy tính";
                        break;
                    default:
                        MessageBox.Show("Bạn chưa chọn chủ đề","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        this.Focus();
                        break;
                }
                string sqlInsert = "Insert into ChuDe values(N'"+cbMaChuDe.Text+"',N'"+tenChuDe+"',N'"+motaChuDe+"')";
                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.ExecuteNonQuery();

                string sql1 = "Select * from ChuDe";
                SqlDataAdapter daCD = new SqlDataAdapter(sql1, conn);
                dtCD = new DataTable();
                daCD.Fill(dtCD);
                dgvChuDe.DataSource = dtCD;
                
            }    
        }

        

        private void btSua1_Click(object sender, EventArgs e)
        {
            
            string sqlUpdate = "Update HoiVien set MaHoiVien=N'" + tbMaHoiVien.Text + "',HoTenHoiVien=N'"+tbHoTen.Text+"',Email=N'"+tbEmail.Text+"',SoDienThoai=N'"+tbSDT.Text+"',DiaChi=N'"+tbDiaChi.Text+"',NgayThamGia=N'"+dateThamGia.Value.ToString()+"'";
            SqlCommand cmd  = new SqlCommand(sqlUpdate, conn);
            cmd.ExecuteNonQuery();


            string sql = "Select * from HoiVien";
            SqlDataAdapter daHV = new SqlDataAdapter(sql, conn);
            dtHV = new DataTable();
            daHV.Fill(dtHV);
            dgvHoiVien.DataSource = dtHV;


        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            string sqlDelete = "Delete HoiVien where MaHoiVien='" + tbMaHoiVien.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.ExecuteNonQuery();

            string sql = "Select * from HoiVien";
            SqlDataAdapter daHV = new SqlDataAdapter(sql, conn);
            dtHV = new DataTable();
            daHV.Fill(dtHV);
            cbMaHoiVien.DataSource = dtHV;
            cbMaHoiVien.DisplayMember = "MaHoiVien";
            dgvHoiVien.DataSource = dtHV;
        }

        private void btXoa3_Click(object sender, EventArgs e)
        {
            string sqlDelete = "Delete ChuDe where MaChuDe='" + cbMaChuDe.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.ExecuteNonQuery();

            string sql1 = "Select * from ChuDe";
            SqlDataAdapter daCD = new SqlDataAdapter(sql1, conn);
            dtCD = new DataTable();
            daCD.Fill(dtCD);
            dgvChuDe.DataSource = dtCD;
        }

        private void btSua3_Click(object sender, EventArgs e)
        {
           
        }
        string tenSach;
        string maChuDe;
        string tacgia;
        int soluong;
        private void btThem4_Click(object sender, EventArgs e)
        {
            bool isCotain = false;
            foreach (DataRow row in dtSach.Rows)
            {
                if (row.Field<string>("MaSach") == cbMaSachSach.Text)
                {
                    isCotain = true;
                    MessageBox.Show("Ma sach nay da co","Thong bao",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                }
            }
            if (isCotain == false)
            {
                switch (cbMaSachSach.Text)
                {
                    case "001":
                        tenSach = "Nguyên lý lập trình hướng đối tượng";
                        maChuDe = "001";
                        tacgia = "Tran Quang Duc Dung";
                        soluong = 100;
                        break;
                    case "002":
                        tenSach = "Lập trình Java thật giản đơn";
                        maChuDe = "001";
                        tacgia = "Nguyen Tien Dung";
                        soluong = 100;
                        break;
                    case "003":
                        tenSach = "Giải tích hàm một biến";
                        maChuDe = "002";
                        tacgia = "Trương Doãn Hùng";
                        soluong = 100;
                        break;
                    case "004":
                        tenSach = "Giải tích hàm nhiều biến";
                        maChuDe = "002";
                        tacgia = "Trương Doãn Hùng";
                        soluong = 100;
                        break;
                    case "005":
                        tenSach = "Thế giới quan";
                        maChuDe = "003";
                        tacgia = "Nguyễn Đức Thành Long";
                        soluong = 100;
                        break;
                    case "006":
                        tenSach = "Tuổi trẻ và những ước mơ";
                        maChuDe = "003";
                        tacgia = "Hoang Hai Dang";
                        soluong = 100;
                        break;
                    case "007":
                        tenSach = "Phân tích thiết kế hệ thống";
                        maChuDe = "004";
                        tacgia = "Hoàng Phi Hồng";
                        soluong = 100;
                        break;
                    default:
                        MessageBox.Show("Bạn chưa nhập mã sách cần tra cứu...Vui lòng nhập!!!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                string sqlInsert = "Insert into Sach values('" + cbMaSachSach.Text + "',N'" + tenSach + "','" + maChuDe + "',N'" + tacgia + "','"+soluong+"')";
                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.ExecuteNonQuery();

                string sql3 = "Select * from Sach";
                SqlDataAdapter daS = new SqlDataAdapter(sql3, conn);
                dtSach = new DataTable();
                daS.Fill(dtSach);
                cbMaSach.DataSource = dtSach;
                cbMaSach.DisplayMember = "MaSach";
                dgvSach.DataSource = dtSach;
            }
        }
            

        private void dgvChuDe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaChuDe.Text = dgvChuDe.CurrentRow.Cells["MaChuDe"].Value.ToString();
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaSachSach.Text = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();
        }

        private void btXoa4_Click(object sender, EventArgs e)
        {
            string sqlDelete = "Delete Sach where MaSach='" + cbMaSachSach.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.ExecuteNonQuery();

            string sql2 = "Select * from Sach";
            SqlDataAdapter daS = new SqlDataAdapter(sql2, conn);
            dtSach = new DataTable();
            daS.Fill(dtSach);
            cbMaSach.DataSource = dtSach;
            cbMaSach.DisplayMember = "MaSach";
            dgvSach.DataSource = dtSach;
        }

        private void btThem2_Click(object sender, EventArgs e)
        {
            bool isCotain = false;
            foreach (DataRow row in dtPM.Rows)
            {
                if (row.Field<string>("MaPhieuMuon") == tbMaPhieuMuon.Text)
                {
                    isCotain = true;
                    MessageBox.Show("Ma phieu muon da ton tai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            if (isCotain==false)
            {
                dateHenTra.Value = dateNgayMuon.Value.AddDays(40);
                string sqlInsert = "Insert into PhieuMuon values('" + tbMaPhieuMuon.Text + "','" + cbMaSach.Text + "','" + cbMaHoiVien.Text + "','" + dateNgayMuon.Value + "','" + dateHenTra.Value + "')";
                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.ExecuteNonQuery();

                string sql3 = "Select * from PhieuMuon";
                SqlDataAdapter daPM = new SqlDataAdapter(sql3, conn);
                dtPM = new DataTable();
                daPM.Fill(dtPM);
                dgvPhieuMuon.DataSource = dtPM;

                string sqlTK = "select 100-count(MaPhieuMuon) as SoLuongSachCon,MaSach from PhieuMuon group by MaSach";
                SqlDataAdapter daTK = new SqlDataAdapter(sqlTK, conn);
                dtTK = new DataTable();
                daTK.Fill(dtTK);
                dgvTK.DataSource = dtTK;
            }
        }

        private void btSua2_Click(object sender, EventArgs e)
        {
            dateHenTra.Value = dateNgayMuon.Value.AddDays(40);
            string sqlUpdate = "update PhieuMuon set MaPhieuMuon='" + tbMaPhieuMuon.Text + "',MaSach='" + cbMaSach.Text + "',MaHoiVien='" + cbMaHoiVien.Text + "',NgayMuon='" + dateNgayMuon.Value + "',NgayHenTra='" + dateHenTra.Value + "'";
            SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
            cmd.ExecuteNonQuery();

            string sql = "select * from PhieuMuon";
            SqlDataAdapter daPM = new SqlDataAdapter(sql, conn);
            dtPM = new DataTable();
            daPM.Fill(dtPM);
            dgvPhieuMuon.DataSource = dtPM;

            string sqlTK = "select 100-count(MaPhieuMuon) as SoLuongSachCon,MaSach from PhieuMuon group by MaSach";
            SqlDataAdapter daTK = new SqlDataAdapter(sqlTK, conn);
            dtTK = new DataTable();
            daTK.Fill(dtTK);
            dgvTK.DataSource = dtTK;
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaPhieuMuon.Text = dgvPhieuMuon.CurrentRow.Cells["MaPhieuMuon"].Value.ToString();
            cbMaSach.Text = dgvPhieuMuon.CurrentRow.Cells["MaSach"].Value.ToString();
            cbMaHoiVien.Text = dgvPhieuMuon.CurrentRow.Cells["MaHoiVien"].Value.ToString();
            dateNgayMuon.Text = dgvPhieuMuon.CurrentRow.Cells["NgayMuon"].Value.ToString();
            dateHenTra.Text = dgvPhieuMuon.CurrentRow.Cells["NgayHenTra"].Value.ToString();
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            string sqlDelete = "Delete PhieuMuon  where MaPhieuMuon='" + tbMaPhieuMuon.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.ExecuteNonQuery();

            string sql = "select * from PhieuMuon";
            SqlDataAdapter daPM = new SqlDataAdapter(sql, conn);
            dtPM = new DataTable();
            daPM.Fill(dtPM);
            dgvPhieuMuon.DataSource = dtPM;

            string sqlTK = "select 100-count(MaPhieuMuon) as SoLuongSachCon,MaSach from PhieuMuon group by MaSach";
            SqlDataAdapter daTK = new SqlDataAdapter(sqlTK, conn);
            dtTK = new DataTable();
            daTK.Fill(dtTK);
            dgvTK.DataSource = dtTK;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            dangnhap f = new dangnhap();
            f.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}

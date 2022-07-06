using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace quanlythuvienSachbaitaplon
{
    public partial class giaodien : Form
    {
        public giaodien()
        {
            InitializeComponent();
        }
        bool isThoat = true;
        int dongdangchon;
        int thanhtien = 0;
        DataTable dtHVien;
        DataTable dtPM;
        DataTable dtSach;
        DataTable dtDauSach;
        DataTable dtChuDe;
        DataTable thongke;
        private void giaodien_Load(object sender, EventArgs e)
        {
            //====================Hội viên===========================
            dtHVien = new DataTable("dtHVien");
            if (System.IO.File.Exists("dtHVien.json"))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader("dtHVien.json");
                string str = reader.ReadToEnd();
                if (JsonConvert.DeserializeObject<DataTable>(str).Rows.Count == 0)
                {
                    dtHVien.Columns.Add("Mã hội viên");
                    dtHVien.Columns.Add("Họ và tên");
                    dtHVien.Columns.Add("Email");
                    dtHVien.Columns.Add("SĐT");
                    dtHVien.Columns.Add("Địa chỉ");
                    dtHVien.Columns.Add("Ngày tham gia");
                }
                else
                {
                    dtHVien = JsonConvert.DeserializeObject<DataTable>(str);
                }
            }
            else if (dtHVien.Rows.Count == 0)
            {
                dtHVien.Columns.Add("Mã hội viên");
                dtHVien.Columns.Add("Họ và tên");
                dtHVien.Columns.Add("Email");
                dtHVien.Columns.Add("SĐT");
                dtHVien.Columns.Add("Địa chỉ");
                dtHVien.Columns.Add("Ngày tham gia");
            }
            dataGridView1.DataSource = dtHVien;
            //======================================================

            //================Phieu muon=============================
            dtPM = new DataTable("dtPM");
            if (System.IO.File.Exists("dtPM.json"))
            {
                System.IO.StreamReader reader1 = new System.IO.StreamReader("dtPM.json");
                string str1 = reader1.ReadToEnd();
                if (JsonConvert.DeserializeObject<DataTable>(str1).Rows.Count == 0)
                {
                    dtPM.Columns.Add("Phiếu mượn");
                    dtPM.Columns.Add("Mã sách");
                    dtPM.Columns.Add("Mã hội viên");
                    dtPM.Columns.Add("Ngày mượn");
                    dtPM.Columns.Add("Ngày trả");
                    dtPM.Columns.Add("Ngày hẹn trả");
                    dtPM.Columns.Add("Thành tiền");
                }
                else
                {
                    dtPM = JsonConvert.DeserializeObject<DataTable>(str1);
                }
            }
            else if (dtPM.Rows.Count == 0)
            {
                dtPM.Columns.Add("Phiếu mượn");
                dtPM.Columns.Add("Mã sách");
                dtPM.Columns.Add("Mã hội viên");
                dtPM.Columns.Add("Ngày mượn");
                dtPM.Columns.Add("Ngày trả");
                dtPM.Columns.Add("Ngày hẹn trả");
                dtPM.Columns.Add("Tình trạng");
                dtPM.Columns.Add("Thành tiền");
            }
            cbHoiVien.DataSource = dtHVien;
            cbHoiVien.DisplayMember = "Mã hội viên";
            dataGridView2.DataSource = dtPM;

            //=================================================


            //==================Sach===========================
            dtSach = new DataTable("dtSach");
            if (System.IO.File.Exists("dtSach.json"))
            {
                System.IO.StreamReader reader2 = new System.IO.StreamReader("dtSach.json");
                string str2 = reader2.ReadToEnd();
                if (JsonConvert.DeserializeObject<DataTable>(str2).Rows.Count == 0)
                {
                    dtSach.Columns.Add("Mã sách");
                    dtSach.Columns.Add("Mã đầu sách");
                    dtSach.Columns.Add("Năm xuất bản");
                    dtSach.Columns.Add("Giá bìa");
                    dtSach.Columns.Add("Tình trạng sách");
                    dtSach.Columns.Add("Thành tiền");
                }
                else
                {
                    dtSach = JsonConvert.DeserializeObject<DataTable>(str2);
                }
            }
            else if (dtSach.Rows.Count == 0)
            {
                dtSach.Columns.Add("Mã sách");
                dtSach.Columns.Add("Mã đầu sách");
                dtSach.Columns.Add("Năm xuất bản");
                dtSach.Columns.Add("Giá bìa");
                dtSach.Columns.Add("Tình trạng sách");
                dtSach.Columns.Add("Thành tiền");
            }
            cbMaSach.DataSource = dtPM;
            cbMaSach.DisplayMember = "Mã sách";
            dataGridView3.DataSource = dtSach;

            //===============================================\

            //=================Dau Sach=======================
            dtDauSach = new DataTable("dtDauSach");
            if (System.IO.File.Exists("dtDauSach.json"))
            {
                System.IO.StreamReader reader3 = new System.IO.StreamReader("dtDauSach.json");
                string str3 = reader3.ReadToEnd();
                if (JsonConvert.DeserializeObject<DataTable>(str3).Rows.Count == 0)
                {
                    dtDauSach.Columns.Add("Mã đầu sách");
                    dtDauSach.Columns.Add("Mã chủ đề");
                    dtDauSach.Columns.Add("Tên đầu sách");
                    dtDauSach.Columns.Add("Tên tác giả");
                }
                else
                {
                    dtDauSach = JsonConvert.DeserializeObject<DataTable>(str3);
                }
            }
            else if (dtDauSach.Rows.Count == 0)
            {
                dtDauSach.Columns.Add("Mã đầu sách");
                dtDauSach.Columns.Add("Mã chủ đề");
                dtDauSach.Columns.Add("Tên đầu sách");
                dtDauSach.Columns.Add("Tên tác giả");
            }
            cbMaDauSach.DataSource = dtSach;
            cbMaDauSach.DisplayMember = "Mã đầu sách";
            dataGridView4.DataSource = dtDauSach;
            //=================================================

            //========================ChuDe=============================
            dtChuDe = new DataTable("dtChuDe");
            if (System.IO.File.Exists("dtChuDe.json"))
            {
                System.IO.StreamReader reader4 = new System.IO.StreamReader("dtChuDe.json");
                string str4 = reader4.ReadToEnd();
                if (JsonConvert.DeserializeObject<DataTable>(str4).Rows.Count == 0)
                {
                    dtChuDe.Columns.Add("Mã chủ đề");
                    dtChuDe.Columns.Add("Tên chủ đề");
                    dtChuDe.Columns.Add("Mô tả chủ đề");
                }
                else
                {
                    dtChuDe = JsonConvert.DeserializeObject<DataTable>(str4);
                }
            }
            else if (dtChuDe.Rows.Count == 0)
            {
                dtChuDe.Columns.Add("Mã chủ đề");
                dtChuDe.Columns.Add("Tên chủ đề");
                dtChuDe.Columns.Add("Mô tả chủ đề");
            }
            cbMaChuDe.DataSource = dtDauSach;
            cbMaChuDe.DisplayMember = "Mã chủ đề";
            dataGridView5.DataSource = dtChuDe;

            //==================================================================


            //================Thong ke=====================

            thongke = new DataTable("thongke");
            if (System.IO.File.Exists("thongke.json"))
            {
                System.IO.StreamReader reader5 = new System.IO.StreamReader("thongke.json");
                string str5 = reader5.ReadToEnd();
                if (JsonConvert.DeserializeObject<DataTable>(str5).Rows.Count == 0)
                {
                    thongke.Columns.Add("Họ tên");
                    thongke.Columns.Add("Ngày mượn");
                    thongke.Columns.Add("Ngày trả");
                    thongke.Columns.Add("Tình trạng phiếu mượn");
                    thongke.Columns.Add("Tình trang sách");
                    thongke.Columns.Add("Thành tiền");
                }
                else
                {
                    thongke = JsonConvert.DeserializeObject<DataTable>(str5);
                }
            }
            else if (thongke.Rows.Count == 0)
            {
                thongke.Columns.Add("Họ tên");
                thongke.Columns.Add("Ngày mượn");
                thongke.Columns.Add("Ngày trả");
                thongke.Columns.Add("Tình trạng phiếu mượn");
                thongke.Columns.Add("Tình trang sách");
                thongke.Columns.Add("Thành tiền");
            }
            thongke.Rows.Add(tbHoTenHoiVien.Text, datePM1.Value.ToString(), datePM3.Value.ToString(), cbTinhTrang.Text, cbTinhTrang1.Text, thanhtien.ToString());
            

        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            dangnhap f = new dangnhap();
            f.Show();
            this.Hide();
        }

        private void giaodien_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
        //==============================HỘI VIÊN================================



        private void btSua1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[dongdangchon].Cells[0].Value = tbMaHoiVien.Text;
            dataGridView1.Rows[dongdangchon].Cells[1].Value = tbHoTenHoiVien.Text;
            dataGridView1.Rows[dongdangchon].Cells[2].Value = tbEmail.Text;
            dataGridView1.Rows[dongdangchon].Cells[3].Value = tbSDT.Text;
            dataGridView1.Rows[dongdangchon].Cells[4].Value = tbDiaChi.Text;
            dataGridView1.Rows[dongdangchon].Cells[5].Value = dateHoiVien.Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongdangchon = e.RowIndex;
            tbMaHoiVien.Text = dataGridView1.Rows[dongdangchon].Cells[0].Value.ToString();
            tbHoTenHoiVien.Text = dataGridView1.Rows[dongdangchon].Cells[1].Value.ToString();
            tbEmail.Text = dataGridView1.Rows[dongdangchon].Cells[2].Value.ToString();
            tbSDT.Text = dataGridView1.Rows[dongdangchon].Cells[3].Value.ToString();
            tbDiaChi.Text = dataGridView1.Rows[dongdangchon].Cells[4].Value.ToString();
            dateHoiVien.Text = dataGridView1.Rows[dongdangchon].Cells[5].Value.ToString();
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dongdangchon);
        }

        private void btLuu1_Click(object sender, EventArgs e)
        {
            string strjson = JsonConvert.SerializeObject(dtHVien);
            System.IO.File.WriteAllText("dtHVien.json", strjson);
        }

        private void btThem1_Click(object sender, EventArgs e)
        {
            dtHVien.Rows.Add(tbMaHoiVien.Text, tbHoTenHoiVien.Text, tbEmail.Text, tbSDT.Text, tbDiaChi.Text, dateHoiVien.Value.ToString());
            tbMaHoiVien.Text = "";
            tbHoTenHoiVien.Text = "";
            tbEmail.Text = "";
            tbSDT.Text = "";
            tbDiaChi.Text = "";
        }

        //===============Kết thúc hội viên=======================

        //===============Phiếu mượn==============================



        private void btThem2_Click(object sender, EventArgs e)
        {
            if (cbTinhTrang.Text == "Hỏng")
            {
                thanhtien = 100000;
            }
            int kiemtra = (datePM3.Value - datePM2.Value).Days - 1;
            if (kiemtra > 0)
            {
                thanhtien += (kiemtra) * 2000;
            }
            dtPM.Rows.Add(tbMaPhieuMuon.Text, tbMaSach.Text, cbHoiVien.Text, datePM1.Value.ToString(), datePM2.Value.ToString(), datePM3.Value.ToString(), cbTinhTrang.Text, thanhtien.ToString());
            tbMaPhieuMuon.Text = "";
            tbMaSach.Text = "";
            cbHoiVien.Text = "";
            cbTinhTrang.Text = "";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongdangchon = e.RowIndex;
            tbMaPhieuMuon.Text = dataGridView2.Rows[dongdangchon].Cells[0].Value.ToString();
            tbMaSach.Text = dataGridView2.Rows[dongdangchon].Cells[1].Value.ToString();
            tbMaHoiVien.Text = dataGridView2.Rows[dongdangchon].Cells[2].Value.ToString();
            datePM1.Text = dataGridView2.Rows[dongdangchon].Cells[3].Value.ToString();
            datePM2.Text = dataGridView2.Rows[dongdangchon].Cells[4].Value.ToString();
            datePM3.Text = dataGridView2.Rows[dongdangchon].Cells[5].Value.ToString();
            cbTinhTrang.Text = dataGridView2.Rows[dongdangchon].Cells[6].Value.ToString();


        }

        private void btSua2_Click(object sender, EventArgs e)
        {
            thanhtien = 0;
            dataGridView2.Rows[dongdangchon].Cells[0].Value = tbMaPhieuMuon.Text;
            dataGridView2.Rows[dongdangchon].Cells[1].Value = tbMaSach.Text;
            dataGridView2.Rows[dongdangchon].Cells[2].Value = tbMaHoiVien.Text;
            dataGridView2.Rows[dongdangchon].Cells[3].Value = datePM1.Value.ToString();
            dataGridView2.Rows[dongdangchon].Cells[4].Value = datePM2.Value.ToString();
            dataGridView2.Rows[dongdangchon].Cells[5].Value = datePM3.Value.ToString();
            dataGridView2.Rows[dongdangchon].Cells[6].Value = cbTinhTrang.Text;
            if (cbTinhTrang.Text == "Hỏng")
            {
                thanhtien += 100000;
            }
            int kiemtra = (datePM3.Value - datePM2.Value).Days - 1;
            if (kiemtra > 0)
            {
                thanhtien += (kiemtra) * 2000;
            }
            dataGridView2.Rows[dongdangchon].Cells[7].Value = thanhtien.ToString();

        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.RemoveAt(dongdangchon);
        }

        private void btLuu2_Click(object sender, EventArgs e)
        {
            string strjson1 = JsonConvert.SerializeObject(dtPM);
            System.IO.File.WriteAllText("dtPM.json", strjson1);
        }
        //===============Kết thúc phiếu mượn=======================


        //====================Sách=================================
        private void btThem3_Click(object sender, EventArgs e)
        {
            if (cbTinhTrang1.Text == "Hỏng")
            {
                thanhtien += 100000;
            }
            dtSach.Rows.Add(cbMaSach.Text, tbMaDauSach.Text, tbNamXuatBan.Text, tbGiaBia.Text, cbTinhTrang1.Text, thanhtien.ToString());
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongdangchon = e.RowIndex;
            cbMaSach.Text = dataGridView3.Rows[dongdangchon].Cells[0].Value.ToString();
            tbMaDauSach.Text = dataGridView3.Rows[dongdangchon].Cells[1].Value.ToString();
            tbNamXuatBan.Text = dataGridView3.Rows[dongdangchon].Cells[2].Value.ToString();
            tbGiaBia.Text = dataGridView3.Rows[dongdangchon].Cells[3].Value.ToString();
            cbTinhTrang1.Text = dataGridView3.Rows[dongdangchon].Cells[4].Value.ToString();
        }

        private void btSua3_Click(object sender, EventArgs e)
        {
            thanhtien = 0;
            dataGridView3.Rows[dongdangchon].Cells[0].Value = cbMaSach.Text;
            dataGridView3.Rows[dongdangchon].Cells[1].Value = tbMaDauSach.Text;
            dataGridView3.Rows[dongdangchon].Cells[2].Value = tbNamXuatBan.Text;
            dataGridView3.Rows[dongdangchon].Cells[3].Value = tbGiaBia.Text;
            dataGridView3.Rows[dongdangchon].Cells[4].Value = cbTinhTrang1.Text;
            if (cbTinhTrang1.Text == "Hỏng")
            {
                thanhtien += 100000;
            }
            dataGridView3.Rows[dongdangchon].Cells[5].Value = thanhtien.ToString();

        }

        private void btXoa3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.RemoveAt(dongdangchon);
        }

        private void btLuu3_Click(object sender, EventArgs e)
        {
            string strjson2 = JsonConvert.SerializeObject(dtSach);
            System.IO.File.WriteAllText("dtSach.json", strjson2);
        }
        //======================ket thuc sach================================


        //===========================Dau Sach==============================
        private void btThem4_Click(object sender, EventArgs e)
        {
            dtDauSach.Rows.Add(cbMaDauSach.Text, tbMaChuDe.Text, tbTenDauSach.Text, tbTenTacGia.Text);
        }

        private void btSua4_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows[dongdangchon].Cells[0].Value = cbMaDauSach.Text;
            dataGridView4.Rows[dongdangchon].Cells[1].Value = tbMaChuDe.Text;
            dataGridView4.Rows[dongdangchon].Cells[2].Value = tbTenDauSach.Text;
            dataGridView4.Rows[dongdangchon].Cells[3].Value = tbTenTacGia.Text;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongdangchon = e.RowIndex;
            cbMaDauSach.Text = dataGridView4.Rows[dongdangchon].Cells[0].Value.ToString();
            tbMaChuDe.Text = dataGridView4.Rows[dongdangchon].Cells[1].Value.ToString();
            tbTenDauSach.Text = dataGridView4.Rows[dongdangchon].Cells[2].Value.ToString();
            tbTenTacGia.Text = dataGridView4.Rows[dongdangchon].Cells[3].Value.ToString();
        }

        private void btXoa4_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.RemoveAt(dongdangchon);
        }

        private void btLuu4_Click(object sender, EventArgs e)
        {
            string strjson3 = JsonConvert.SerializeObject(dtDauSach);
            System.IO.File.WriteAllText("dtDauSach.json", strjson3);
        }
        //======================ket thuc sach================================




        //=====================Chu De=======================================
        private void btThem5_Click(object sender, EventArgs e)
        {
            dtChuDe.Rows.Add(cbMaChuDe.Text, tbTenChuDe.Text, tbMoTaChuDe.Text);
        }

        private void btSua5_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows[dongdangchon].Cells[0].Value = cbMaChuDe.Text;
            dataGridView5.Rows[dongdangchon].Cells[1].Value = tbTenChuDe.Text;
            dataGridView5.Rows[dongdangchon].Cells[2].Value = tbMoTaChuDe.Text;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongdangchon = e.RowIndex;
            cbMaChuDe.Text = dataGridView5.Rows[dongdangchon].Cells[0].Value.ToString();
            tbTenChuDe.Text = dataGridView5.Rows[dongdangchon].Cells[1].Value.ToString();
            tbMoTaChuDe.Text = dataGridView5.Rows[dongdangchon].Cells[2].Value.ToString();
        }

        private void btXoa5_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows.RemoveAt(dongdangchon);
        }

        private void btLuu5_Click(object sender, EventArgs e)
        {
            string strjson4 = JsonConvert.SerializeObject(dtChuDe);
            System.IO.File.WriteAllText("dtChuDe.json", strjson4);
        }
        //============xu ly du lieu

        private void tbMaHoiVien_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbMaHoiVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbHoTenHoiVien_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbHoTenHoiVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập họ tên hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbEmail.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập email hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbSDT_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbSDT.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập số điện thoại hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbDiaChi_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbDiaChi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập số địa chỉ hội viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbMaPhieuMuon_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbMaPhieuMuon.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã phiếu mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbMaSach_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbMaSach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbMaDauSach_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbMaDauSach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã đầu sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbNamXuatBan_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbNamXuatBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập năm xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbGiaBia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbGiaBia.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập giá bìa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbMaChuDe_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbMaChuDe.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã chủ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbTenDauSach_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbTenDauSach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên đầu sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbTenTacGia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbTenTacGia.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbTenChuDe_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbTenChuDe.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên chủ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbMoTaChuDe_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbMoTaChuDe.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mô tả chủ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai kiểu ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }

        private void tbMaHoiVien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


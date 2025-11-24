using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Stripe;
//using Stripe.Checkout;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;

namespace WinFormsfinal
{
    public partial class BieuMauDatPhong : Form
    {
        string connectionString = @"Data Source=project_final.db;Version=3;";
        string maPhong;
        DateTime ngayDat;
        TimeSpan gioBD, gioKT;

        public BieuMauDatPhong(string maPhong, DateTime ngay, TimeSpan bd, TimeSpan kt)
        {
            InitializeComponent();
            this.maPhong = maPhong;
            this.ngayDat = ngay;
            this.gioBD = bd;
            this.gioKT = kt;

        }

        private void BieuMauDatPhong_Load(object sender, EventArgs e)
        {
            LoadThongTinPhong();

            string[] gioList = { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
            cbbGioBD.Items.AddRange(gioList);
            cbbGioKT.Items.AddRange(gioList);

            dateNgayDat.Value = ngayDat;
            cbbGioBD.Text = gioBD.ToString(@"hh\:mm");
            cbbGioKT.Text = gioKT.ToString(@"hh\:mm");

            TinhTienCoc();

            cbbLyDo.Items.AddRange(new string[]
            {
                "Thảo luận nhóm",
                "Thuyết trình nhóm",
                "Khác"
            });

            dateNgayDat.ValueChanged += (s, e) => KiemTraHopLe();
            cbbGioBD.SelectedIndexChanged += (s, e) => KiemTraHopLe();
            cbbGioKT.SelectedIndexChanged += (s, e) => KiemTraHopLe();

        }

        private void LoadThongTinPhong()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Phong WHERE MaPhong=@ma";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maPhong);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtTenPhong.Text = r["TenPhong"].ToString();
                            txtCSVC.Text = r["CoSoVatChat"].ToString();
                            txtSucChua.Text = r["SucChua"].ToString();
                        }
                    }
                }
            }
        }

        private void KiemTraHopLe()
        {
            DateTime ngay = dateNgayDat.Value.Date;

            if ((ngay - DateTime.Today).TotalDays > 2)
            {
                MessageBox.Show("Chỉ được đặt trước tối đa 2 ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeSpan.TryParse(cbbGioBD.Text, out TimeSpan gioBD) ||
                !TimeSpan.TryParse(cbbGioKT.Text, out TimeSpan gioKT))
                return;

            if (gioKT <= gioBD)
            {
                MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((gioKT - gioBD).TotalHours > 4)
            {
                MessageBox.Show("Không được đặt quá 4 tiếng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kiểm tra trùng lịch trong DB
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM DonDatPhongHocNhom 
                       WHERE MaPhong=@phong AND NgayDat=@ngay 
                       AND (GioBatDau < @kt AND GioKetThuc > @bd)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@phong", maPhong);
                    cmd.Parameters.AddWithValue("@ngay", ngay.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@bd", gioBD.ToString(@"hh\:mm"));
                    cmd.Parameters.AddWithValue("@kt", gioKT.ToString(@"hh\:mm"));
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Phòng này đã được đặt trong khung giờ bạn chọn, vui lòng chọn lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            //Nếu mọi thứ hợp lệ thì cập nhật lại tiền cọc
            gioBD = TimeSpan.Parse(cbbGioBD.Text);
            gioKT = TimeSpan.Parse(cbbGioKT.Text);
            this.gioBD = gioBD;
            this.gioKT = gioKT;
            TinhTienCoc();
        }


        private void TinhTienCoc()
        {
            decimal donGia = 0;
            if (maPhong.StartsWith("P5")) donGia = 15000;
            else if (maPhong.StartsWith("P10")) donGia = 20000;
            else if (maPhong.StartsWith("P12")) donGia = 25000;

            double soGio = (gioKT - gioBD).TotalHours;
            decimal tongTien = donGia * (decimal)soGio;
            txtTienCoc.Text = (tongTien * 0.3m).ToString("N0");
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNguoiDatPhong.Text) ||
                string.IsNullOrWhiteSpace(txtMaTheThuVien.Text) ||
                string.IsNullOrWhiteSpace(cbbLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbLyDo.Text == "Khác" && string.IsNullOrWhiteSpace(txtKhac.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng thành viên tham gia!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = (int)nudSoLuong.Value;
            if (int.TryParse(txtSucChua.Text, out int sucChua) && soLuong > sucChua)
            {
                MessageBox.Show("Số lượng thành viên vượt quá sức chứa phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã thẻ thư viện có tồn tại không 
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM NguoiDung WHERE MaSoThe = @mathe";
                using (var cmd = new SQLiteCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@mathe", txtMaTheThuVien.Text);
                    int exists = Convert.ToInt32(cmd.ExecuteScalar());
                    if (exists == 0)
                    {
                        MessageBox.Show("Mã thẻ thư viện không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            }
            try
            {

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string maDatPhong = "DDP" + DateTime.Now.Ticks.ToString().Substring(10);
                    string sql = @"INSERT INTO DonDatPhongHocNhom 
                               (MaDatPhong, MaPhong, MaTheThuVien, NgayDat, GioBatDau, GioKetThuc, MucDich, GhiChu, TienCoc, NgayTao)
                               VALUES (@ma, @phong, @the, @ngay, @bd, @kt, @mucdich, @ghichu, @tiencoc, @ngaytao)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maDatPhong);
                        cmd.Parameters.AddWithValue("@phong", maPhong);
                        cmd.Parameters.AddWithValue("@the", txtMaTheThuVien.Text);
                        cmd.Parameters.AddWithValue("@ngay", ngayDat.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@bd", gioBD.ToString(@"hh\:mm"));
                        cmd.Parameters.AddWithValue("@kt", gioKT.ToString(@"hh\:mm"));
                        cmd.Parameters.AddWithValue("@mucdich", cbbLyDo.Text);
                        cmd.Parameters.AddWithValue("@ghichu", txtKhac.Text);
                        cmd.Parameters.AddWithValue("@tiencoc", txtTienCoc.Text);
                        cmd.Parameters.AddWithValue("@ngaytao", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }

                    //}

                    //MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    // API stripe payment methods
                    //    Stripe.StripeConfiguration.ApiKey = "sk_test_51SWHxZBw1R11yJh1XR2Is4qBrqsAtw7wAhpKJIGVP1FjiGvAu54CZzwGVUvrBuNLtTGuB11tWZyPoDwQiOtG11pA00seDNa4wu";

                    //    var options = new Stripe.Checkout.SessionCreateOptions
                    //    {
                    //        PaymentMethodTypes = new List<string> { "card" },
                    //        Mode = "payment",
                    //        LineItems = new List<Stripe.Checkout.SessionLineItemOptions>
                    //    {
                    //        new Stripe.Checkout.SessionLineItemOptions
                    //        {
                    //            PriceData = new Stripe.Checkout.SessionLineItemPriceDataOptions
                    //            {
                    //                Currency = "usd", 
                    //                //UnitAmount = (long)(decimal.Parse(txtTienCoc.Text) * 100),
                    //                UnitAmount = (long)(decimal.Parse(txtTienCoc.Text) / 25000 * 100), // quy đổi tạm VNĐ sang USD
                    //                ProductData = new Stripe.Checkout.SessionLineItemPriceDataProductDataOptions
                    //                {
                    //                    Name = $"Đặt phòng {txtTenPhong.Text}" //ban đầu là cbb
                    //                }
                    //            },
                    //            Quantity = 1
                    //        }
                    //    },
                    //        SuccessUrl = "https://example.com/payment-success",
                    //        CancelUrl = "https://example.com/payment-cancel"
                    //    };

                    //    var service = new Stripe.Checkout.SessionService();
                    //    Stripe.Checkout.Session session = service.Create(options);

                    //    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    //    {
                    //        FileName = session.Url,
                    //        UseShellExecute = true
                    //    });
                    //}
                    //    catch (Exception ex)
                    //{
                    //    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
                    //}


                    // VietQR API 
                
                    string bank = "OCB";
                    string account = "0024100013455002";

                    string soTien = txtTienCoc.Text.Replace(",", "");

                    string noiDung = $"DatPhong_{maPhong},{txtMaTheThuVien.Text}, {ngayDat}";

                    string vietQR = $"https://img.vietqr.io/image/{bank}-{account}-print.png?amount={soTien}&addInfo={noiDung}";

                    // Mở QR trên trình duyệt
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = vietQR,
                        UseShellExecute = true
                    });
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
            }
        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        //btn hủy
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }  
}



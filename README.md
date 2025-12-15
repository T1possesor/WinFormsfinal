# WinFormsfinal
HỆ THỐNG QUẢN LÝ THƯ VIỆN – NHÓM 07
Ứng dụng Desktop (WinForms – C#, .NET Framework – SQLite – Guna UI)

1. Giới thiệu đề tài
Trong bối cảnh nhu cầu đọc sách và sử dụng không gian học tập ngày càng lớn, các thư viện tư nhân phải đối mặt với thách thức trong việc quản lý kho sách, độc giả, phòng học nhóm và các quy trình mượn trả. Việc quản lý thủ công dễ dẫn đến:
- Thất thoát tài sản
- Khó kiểm soát hạn trả
- Tính phí phạt không chính xác
- Khó theo dõi độc giả và phòng học
- Nhóm thực hiện xây dựng Ứng dụng Quản lý Thư viện Desktop nhằm số hóa toàn bộ hoạt động của thư viện tư nhân theo hướng chuyên nghiệp, trực quan và hiệu quả.

2. Mục tiêu hệ thống
Mục tiêu kỹ thuật
- Sử dụng C#, WinForms, SQLite, thư viện giao diện Guna UI
- Thiết kế DB bài bản, trực quan, dễ mở rộng
- Xây dựng đầy đủ nghiệp vụ thư viện
- Mục tiêu chức năng
- Hệ thống gồm các module chính:
- Quản lý kho sách (nhập – xuất – phân loại)
- Quản lý độc giả & thẻ thư viện
- Mượn – trả – tính phí phạt tự động
- Đặt phòng học nhóm
- Quản lý phòng học & đơn đặt
- Dashboard thống kê trực quan

3. Kiến trúc hệ thống
- Ngôn ngữ: C# (.NET Framework)
- Giao diện: WinForms + Guna UI
- Cơ sở dữ liệu	SQLite
- Công cụ hỗ trợ: Figma (UI/UX), PDF Viewer, QR Payment
  
4. Cơ sở dữ liệu (ERD & các bảng chính)
- CSDL gồm các bảng:
- Sach, NguoiDung, TaiKhoan
- Phong, DonDatPhong, ThanhToanCoc
- PhieuMuon, ChiTietPhieuMuon, LichSuMuon
- PhieuNhap, ChiTietPhieuNhap

5. Chức năng hệ thống
5.1. Đăng nhập – Đăng ký – Quên mật khẩu

- Hỗ trợ 2 vai trò: Admin & Người đọc
- Đăng ký tài khoản mới với kiểm tra trùng Email, trùng Username
- Quên mật khẩu: xác thực bằng Username + Email

5.2. Chức năng của Người đọc
Xem danh sách sách
- Tìm kiếm theo tên, tác giả, thể loại
- Tìm kiếm tiếng Việt không dấu
- Xem chi tiết sách (bìa, mô tả, số lượng, vị trí kệ)

Xem lịch sử mượn – kèm tiền phạt
- Gộp chung bảng lịch sử + phí phạt (cải tiến so với VNU-LIC)
- Tính tổng tiền phạt tự động

Đặt phòng học nhóm
- Chọn phòng, chọn khung giờ
- Kiểm tra trùng lịch
- Hệ thống tự tính tiền cọc → hiển thị QR thanh toán

Làm thẻ thư viện
- Hiển thị mã thẻ, trạng thái thẻ
- Chỉ đọc – không tự chỉnh sửa

Chỉnh sửa thông tin cá nhân & ảnh đại diện
5.3. Chức năng Quản lý (Admin)
Quản lý sách
- Thêm / sửa / xóa sách
- Theo dõi tổng số bản, số đang mượn, số còn lại, số mất
- Tìm kiếm nhanh theo tên sách
- Dữ liệu cập nhật dựa trên mượn – trả – nhập sách

Nhập sách
- Danh sách phiếu nhập
- Lập phiếu nhập mới
- Gợi ý sách tự động theo từ khóa
- Thêm nhanh biên mục nếu sách chưa tồn tại
- Xem chi tiết phiếu nhập dạng slide–panel
- Import & lưu hóa đơn PDF

Mượn sách
- Tìm độc giả bằng mã thẻ
- Kiểm tra ràng buộc:
- quá hạn chưa trả
- vượt số lượng mượn (tối đa 3 cuốn)
- mã sách không tồn tại
- Nhập nhiều mã sách cùng lúc (cải tiến hơn Koha)
- Tạo phiếu mượn + chi tiết phiếu mượn

Trả sách
- Tính phạt tự động:
- Trễ hạn
- Hư hỏng / mất sách (150% giá bìa)
- Chọn phương thức thanh toán
- Không cho chỉnh sửa lại phiếu sau khi đã trả

Quản lý độc giả
- Tìm kiếm thời gian thực
- Bộ lọc trạng thái thẻ
- Không cho xóa nếu độc giả còn sách chưa trả

Quản lý phòng học]
- Thêm – sửa – xóa phòng
- Quản lý trạng thái phòng
- Tìm kiếm và thao tác nhanh trên lưới

Quản lý đơn đặt phòng
- Xem – sửa – hủy đơn
- Kiểm tra trùng thời gian tự động
- Hủy đơn hàng loạt

Thống kê
- Lượt mượn theo thể loại
- Tình trạng sách khi mượn/trả
- Tình trạng thẻ độc giả
- Mục đích đặt phòng
- Các chỉ số: tổng sách, độc giả hoạt động, phòng được sử dụng…

6. Quy trình nghiệp vụ chính
- Mượn sách
- Trả sách
- Nhập sách
- Tra cứu
- Quản lý độc giả
- Đặt phòng học nhóm
- Làm thẻ thư viện

7. Hướng dẫn cài đặt & chạy hệ thống
Yêu cầu:
- Windows 10 trở lên
- .NET Framework phù hợp version dự án
- SQLite

Cách chạy:
- git clone <link-repo>
- Run project

8. Giao diện người dùng
Toàn bộ UI thiết kế trên Figma và implement trong WinForms (Xem mục 2.2 & 2.3 của báo cáo) 
Nhóm07.

Bao gồm:
- Đăng nhập / Đăng ký
- Trang chủ người đọc
- Xem sách & chi tiết sách
- Đặt phòng học nhóm

9. Thành viên nhóm 07
- Bùi Mai Yến Linh – Trưởng nhóm
- Huỳnh Thị Thúy Phương
- Trần Thị Thanh Phương
- Phạm Ngọc Hồng Như
- Mai Đức Phát

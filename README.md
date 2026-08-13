# Jewelry E-Commerce ASP.NET

Website thương mại điện tử bán trang sức, xây dựng bằng **ASP.NET Core (.NET 6.0)**.
Đồ án môn học **Lập trình Web Nâng Cao** – Khoa Công Nghệ Thông Tin, Trường Đại học Ngoại ngữ - Tin học TP.HCM (HUFLIT).

> Giảng viên hướng dẫn: Nguyễn Thanh Vũ

## Giới thiệu

Đây là hệ thống website bán trang sức trực tuyến, cho phép khách hàng duyệt sản phẩm, đặt hàng, thanh toán qua VietQR, theo dõi đơn hàng và tương tác qua chatbox tư vấn. Hệ thống có khu vực quản trị (Admin) riêng để quản lý sản phẩm, đơn hàng, người dùng, doanh thu và nội dung website.

Các trang tham khảo giao diện: [Flower Jewellery](https://www.flowerjewellery.com/), [Tierra](https://www.tierra.vn/), [Pandora Norbreeze](https://pandora.norbreeze.vn/).

## Tính năng chính

### Phía khách hàng
- Đăng ký, đăng nhập, đăng xuất, quên/đổi mật khẩu, khôi phục tài khoản
- Xem danh sách sản phẩm (grid/list), tìm kiếm, lọc theo danh mục
- Xem chi tiết sản phẩm (ảnh chính, ảnh phụ, mô tả)
- Giỏ hàng: thêm/xóa/cập nhật số lượng sản phẩm
- Quản lý địa chỉ giao hàng, chọn nhận tại cửa hàng hoặc giao tận nơi
- Thanh toán đơn hàng qua **VietQR** hoặc thanh toán khi nhận hàng (COD)
- Xem lịch sử và chi tiết đơn hàng đã đặt
- Đánh giá sản phẩm
- Đọc tin tức/blog, xem giá vàng cập nhật
- Trang giới thiệu, hệ thống cửa hàng, quan hệ cổ đông, liên hệ
- Chatbox tư vấn hỗ trợ khách hàng

### Phía quản trị (Admin)
- Dashboard tổng quan
- CRUD sản phẩm và phân loại sản phẩm
- Quản lý đơn hàng (chưa giao / đã giao, xuất Excel)
- Quản lý người dùng và phân quyền
- Thống kê doanh thu (biểu đồ theo ngày)
- Quản lý banner, blog/tin tức
- Quản lý chatbox và bình luận/đánh giá
- Cài đặt hệ thống

## Sơ đồ chức năng

```
Home ─┬─ Sản phẩm
      ├─ Tin tức
      ├─ Chatbox
      ├─ Liên hệ
      ├─ Giỏ hàng ─ Thanh Toán ─ Client
      └─ Đăng nhập ─┬─ Đăng ký
                     ├─ Giới thiệu
                     └─ Admin Dashboard
```

## Kiến trúc & Cơ sở dữ liệu

Hệ thống sử dụng mô hình **MVC + Entity Framework Core** với các thực thể chính:

- `Product` – thông tin sản phẩm, liên kết `Category`
- `Category` – phân loại sản phẩm
- `Order` / `OrderDetail` / `CartLine` – đơn hàng, chi tiết đơn hàng, giỏ hàng
- `ApplicationUser` – tài khoản người dùng (ASP.NET Identity), phân quyền Admin/Customer

Xem chi tiết class diagram, usecase diagram, activity diagram và sequence diagram trong báo cáo đồ án (`Báo_cáo_LTWNC.pdf`).

## Công nghệ sử dụng

| Công nghệ | Vai trò |
|---|---|
| **ASP.NET Core (.NET 6.0)** + Razor Pages / MVC | Nền tảng phát triển chính |
| **Blazor Server** | Tương tác giao diện thời gian thực |
| **Entity Framework Core** | ORM, thao tác cơ sở dữ liệu |
| **ASP.NET Identity** | Xác thực & phân quyền người dùng |
| **VietQR API** | Sinh mã QR thanh toán chuyển khoản |
| **Chatbox AI** | Tư vấn, hỗ trợ khách hàng tự động |
| **Chart (biểu đồ)** | Thống kê doanh thu |
| **Bootstrap** | Giao diện responsive |

## Cài đặt & chạy dự án

### Yêu cầu
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB hoặc SQL Server instance)
- Visual Studio 2022 / VS Code

### Các bước

```bash
# Clone repository
git clone https://github.com/yennhi712/jewelry-ecommerce-aspnet.git
cd jewelry-ecommerce-aspnet

# Khôi phục packages
dotnet restore

# Cập nhật connection string trong appsettings.json
# "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=JewelryStoreDb;Trusted_Connection=True;"

# Áp dụng migrations để tạo database
dotnet ef database update

# Chạy ứng dụng
dotnet run
```

Ứng dụng mặc định chạy tại `https://localhost:5001`.

### Tài khoản mẫu
| Vai trò | Tài khoản | Mật khẩu |
|---|---|---|
| Admin | `Admin` | *Admin123* |
| Khách hàng | *(đăng ký mới qua trang Register)* | — |

## Cấu trúc thư mục (tổng quan)

```
├── Controllers/        # AccountController, ProductsController, OrderController, ...
├── Models/              # Product, Category, Order, OrderDetail, CartLine, ApplicationUser
├── Views/                # Razor views (Products, CustomerAccount, LienHe, ...)
├── Pages/                # Razor Pages (Cart, Order/Completed, ...)
├── wwwroot/              # CSS, JS, hình ảnh sản phẩm
└── Data/                  # DbContext, migrations, seed data
```

## Tài liệu

Báo cáo chi tiết đồ án (mô tả chức năng, sơ đồ CSDL, giao diện, class/usecase/activity/sequence diagram) được đính kèm trong file `Báo_cáo_LTWNC.pdf`.

## Tác giả

Đồ án môn **Lập trình Web Nâng Cao** – HUFLIT.

## License

Dự án phục vụ mục đích học tập.

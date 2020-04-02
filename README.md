# Perfume Store Web

### Links
Link project https://1drv.ms/u/s!AiFVLPRBePKonP8q_i0SBObHvH_5uA?e=1boc5H \
Link Doc https://1drv.ms/u/s!AiFVLPRBePKonctK8_2oKCDPP-Pstg?e=ibbfEP 

### Cài DB
Mn vô project bằng link ở trên -> tải Perfume_Store.mdf trong folder Model về (nếu chưa có) -> mở sql server management studio -> chọn sql express instance -> Database -> chuột phải -> attach -> Add -> chọn file .mdf đã tải 
### Video hướng dẫn ASP.NET
Đây là playlist dạy ASP mà t thấy ổn nhất vì dạy đủ từ a-z: https://youtu.be/7kJMX8aMesA
## Lịch trình dự kiến:
Lịch trình tiến độ công việc tuần sau
### T7 + CN 
- Thành: Quản lý Product + Product Images
- My:  Quản lý Order + order item
- MAnh: Quản lý user + favorite list
### T2 (có deadline SWR -> giảm workload):
- Thành: load data home
- MAnh: Log in
- My: load product detail
### T3
- Thành: Load category + phân trang + sort
- MAnh: register
- My: chức năng search + nghiên cứu tạo report cho web. 
  - Tạo report bằng  Microsoft report (.rdlc): https://www.youtube.com/watch?v=2q42e7UGssc
  - Tạo report bằng Crystal report: https://www.youtube.com/watch?v=74zNM0llQkw
### T4
- Thành: cart
- MAnh: Viết hướng dẫn sử dụng các phần đã làm
- My: Chức năng tạo report
  - Báo cáo doanh thu và doanh số ngày/tuần/tháng/năm
  - Số tài khoản tạo mới trong ngày/tuần/tháng/năm
### T5
- Thành: Viết hướng dẫn sử dụng các phần đã làm
- MAnh: place order
- My: Tạo report cho winform
  - Tạo report bằng Crystal report: https://timoday.edu.vn/tao-bao-cao-voi-crystal-report-trong-c/, 
  - Tạo report bằng rdlc: https://www.youtube.com/watch?v=TpWD9k6nZ0k, https://www.youtube.com/watch?v=WGKzFKgeoo8
### T6: 
- Thành: Test admin pages
- MAnh: Test user pages
- My: Viết hướng dẫn sử dụng các phần đã làm
### T7: 
Sửa lỗi + hoàn thành web

## Chỉnh giao diện cho Admin
Cách làm chung là copy giao diện tương ứng rồi paste vào trang cần chỉnh. Sau đó Replace code chứa load data của giao diện mới bằng cái của giao diện cũ rồi xóa hết code giao diện cũ đi là xong
### Index 
- Replace tất cả 'th' trừ cái cuối ghi 'Actions'
- Replace tất cả 'td' trừ cái status và cái cuối. Sẽ cần sửa lại code xíu
### Edit, Create
- Replace mấy div có class là form-group row
- Find & Replace 'form-group' bằng 'form-group row'
- Find & Replace 'col-md-10' bằng 'col-md-5'
### Detail 
- Replace tag dl là được
- Sửa code cái nút edit
### Delete 
- Replace tag dl là được

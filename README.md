# Perfume Store Web
Link project https://1drv.ms/u/s!AiFVLPRBePKonP8q_i0SBObHvH_5uA?e=1boc5H \
Mn tải file Perfume_Store.mdf trong folder Model về (nếu chưa có) -> mở sql server management studio -> chọn sql express instance -> Database -> chuột phải -> attach -> Add -> chọn file .mdf đã tải 
## Chỉnh giao diện
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

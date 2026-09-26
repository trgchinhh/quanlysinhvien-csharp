using System;
using System.Text;
using System.Linq;
using System.Text.Json;

public class QuanLySinhVien {
    // Frield 
    
    private int soluongsinhvien;
    private List<SinhVien> danhsachsinhvien = new List<SinhVien>();
    private string duongdandanhsach = "data/danhsachsinhvien.json";
    
    // Constructor

    public QuanLySinhVien(){
        this.soluongsinhvien = 0;
    }

    public QuanLySinhVien(int soluongsinhvien){
        this.soluongsinhvien = soluongsinhvien;
    }

    // Properties

    public int SoLuongSinhVien {
        get { return this.soluongsinhvien; }
        set {
            if(value > 0) {
                this.soluongsinhvien = value;
            } else {
                Console.WriteLine("Số lượng sinh viên phải lớn hơn 0 !");
            }
        }
    }

    // Methods

    public void napdulieudanhsach(){
        if(!Directory.Exists("data")){
            Console.WriteLine("Chưa có thư mục data. Tạo thư mục data/");
            Directory.CreateDirectory("data");
        }
        // demo database 
        if(File.Exists(this.duongdandanhsach)){
            string dulieudanhsach = File.ReadAllText(this.duongdandanhsach);
            this.danhsachsinhvien = JsonSerializer.Deserialize<List<SinhVien>>(dulieudanhsach);
        } 
        else {
            this.danhsachsinhvien = new List<SinhVien> {
                new SinhVien {TenSinhVien = "Trường Chinh", MaSoSinhVien = "DH52400001", DiemSinhVien = 7.6f},
                new SinhVien {TenSinhVien = "Nguyễn Gia Bảo", MaSoSinhVien = "DH52400002", DiemSinhVien = 7.6f},
                new SinhVien {TenSinhVien = "Trần Minh Anh", MaSoSinhVien = "DH52400003", DiemSinhVien = 7.1f},
                new SinhVien {TenSinhVien = "Lê Hoàng Nam", MaSoSinhVien = "DH52400004", DiemSinhVien = 8.3f},
                new SinhVien {TenSinhVien = "Phạm Thanh Tùng", MaSoSinhVien = "DH52400005", DiemSinhVien = 9.1f},
                new SinhVien {TenSinhVien = "Hoàng Ngọc Hân", MaSoSinhVien = "DH52400006", DiemSinhVien = 6.2f},
                new SinhVien {TenSinhVien = "Vũ Tuấn Kiệt", MaSoSinhVien = "DH52400007", DiemSinhVien = 6.7f},
                new SinhVien {TenSinhVien = "Đặng Phương Thảo", MaSoSinhVien = "DH52400008", DiemSinhVien = 3.5f},
                new SinhVien {TenSinhVien = "Bùi Đức Anh", MaSoSinhVien = "DH52400009", DiemSinhVien = 3.0f},
                new SinhVien {TenSinhVien = "Đỗ Khánh Linh", MaSoSinhVien = "DH52400010", DiemSinhVien = 5.8f},
                new SinhVien {TenSinhVien = "Ngô Quốc Huy", MaSoSinhVien = "DH52400011", DiemSinhVien = 7.6f},
                new SinhVien {TenSinhVien = "Hồ Thùy Dương", MaSoSinhVien = "DH52400012", DiemSinhVien = 9.9f},
                new SinhVien {TenSinhVien = "Lý Hoàng Long", MaSoSinhVien = "DH52400013", DiemSinhVien = 7.8f},
                new SinhVien {TenSinhVien = "Phan Mai Phương", MaSoSinhVien = "DH52400014", DiemSinhVien = 1.5f},
                new SinhVien {TenSinhVien = "Võ Đình Khang", MaSoSinhVien = "DH52400015", DiemSinhVien = 6.4f}
            };
            string dulieujson = JsonSerializer.Serialize(
                this.danhsachsinhvien,
                new JsonSerializerOptions { 
                    WriteIndented = true,
                }
            );
            File.WriteAllText(this.duongdandanhsach, dulieujson);
        }
        this.SoLuongSinhVien = this.danhsachsinhvien.Count;
    }

    private void luudulieudanhsach(){
        string dulieujson = JsonSerializer.Serialize(
            danhsachsinhvien, 
            new JsonSerializerOptions {
                WriteIndented = true,
            }
        );
        File.WriteAllText(duongdandanhsach, dulieujson, Encoding.UTF8);
    }

    // nhập số thứ tự (phục vụ cho các hàm sửa, xóa)
    public int NhapSoThuTu(){
        int sothutu;
        do {
            Console.Write("\nNhập số thứ tự (0 để thoát): ");
            int.TryParse(Console.ReadLine()!, out sothutu);
            if(sothutu < 0 || sothutu > this.soluongsinhvien){
                Console.WriteLine("Nhập STT trong khoảng 1 -> {0}", this.soluongsinhvien);
            } else if(sothutu == 0){
                break;
            }
        } while(sothutu < 0 || sothutu > this.soluongsinhvien);
        return sothutu;
    }

    // thêm sinh viên 
    public void ThemThongTinSinhVien(){
        Console.WriteLine("Thêm thông tin sinh viên");
        int soluong;
        do {
            Console.Write("Nhập số lượng Sv muốn thêm (0 để thoát): ");
            int.TryParse(Console.ReadLine()!, out soluong);
            if(soluong < 0){
                Console.WriteLine("Số lượng phải từ 1 trở lên !");
            } else if(soluong == 0){
                return;
            }
        } while(soluong <= 0);
        this.SoLuongSinhVien += soluong; // cập nhật số lượng mới

        for(int i = 0; i < soluong; i++){
            SinhVien sinhvienmoi = new SinhVien();
            Console.WriteLine("Nhập thông tin Sv thứ {0}", i + 1);
            sinhvienmoi.NhapThongTin();
            this.danhsachsinhvien.Add(sinhvienmoi);
        }
        Console.WriteLine("Đã thêm {0} sinh viên vào danh sách", soluong);
        this.XuatDanhSach();
        this.luudulieudanhsach();
    }

    // xóa sinh viên 
    public void XoaThongTinSinhVien(){        
        Console.WriteLine("Xóa thông tin sinh viên");
        this.XuatDanhSach();        
        int sothutu = this.NhapSoThuTu();
        if(sothutu == 0) {
            return;
        }
        string tenmuonxoa =  this.danhsachsinhvien[sothutu - 1].TenSinhVien;
        this.danhsachsinhvien.RemoveAt(sothutu - 1);
        this.SoLuongSinhVien--;
        Console.WriteLine("Đã xóa thông tin sinh viên: {0}", tenmuonxoa);
        this.luudulieudanhsach();
    }

    // sửa thông tin sinh viên 
    public void SuaThongTinSinhVien(){
        Console.WriteLine("Sửa thông tin sinh viên");
        bool thaydoi = false;
        this.XuatDanhSach();
        int sothutu = this.NhapSoThuTu();
        if(sothutu == 0){
            return;
        }
        SinhVien sinhviencanthaythongtin = this.danhsachsinhvien[sothutu - 1];
        Console.WriteLine("Bỏ trống và nhấn Enter để giữ nguyên giá trị cũ");

        Console.Write("Nhập tên: ");
        string tenthay = Console.ReadLine()!;
        if(string.IsNullOrEmpty(tenthay)){
            tenthay = sinhviencanthaythongtin.TenSinhVien;               
        } else thaydoi = true;
        sinhviencanthaythongtin.TenSinhVien = tenthay;

        Console.Write("Nhập mã số: ");
        string masothay = Console.ReadLine()!;
        if(string.IsNullOrEmpty(masothay)){
            masothay = sinhviencanthaythongtin.MaSoSinhVien;                       
        } else thaydoi = true;
        sinhviencanthaythongtin.MaSoSinhVien = masothay;

        Console.Write("Nhập điểm: ");
        float.TryParse(Console.ReadLine()!, out float diemthay);
        if(diemthay <= 0 || diemthay > 10){
            diemthay = sinhviencanthaythongtin.DiemSinhVien;
        } else thaydoi = true;
        sinhviencanthaythongtin.DiemSinhVien = diemthay;
        Console.WriteLine(
            "{0} thay đổi thông tin sinh viên: {1}",
            (thaydoi ? "Đã" : "Không"),
            sinhviencanthaythongtin.TenSinhVien
        );
        this.luudulieudanhsach();
    }

    // hàm lấy tên (chữ cuối) phục vụ sort tên 
    private string LayTenCuoi(string hotensinhvien){
        var hotenkhongkhoangtrang = hotensinhvien.Trim().Split(' ');
        return hotenkhongkhoangtrang[hotenkhongkhoangtrang.Length - 1];
    }

    // sắp xếp thông tin sinh viên 
    public void SapXepThongTinSinhVien(){
        bool hiendanhsach = true;
        while(true){
            Console.WriteLine(
                "SẮP XẾP SINH VIÊN\n" +
                "1. Sắp xếp theo tên (A -> Z)\n" + 
                "2. Sắp xếp theo tên (Z -> A)\n" + 
                "3. Sắp xếp theo điểm (Thấp -> Cao)\n" + 
                "4. Sắp xếp theo điểm (Cao -> Thấp)\n" + 
                "0. Quay lại"
            );
            Console.Write("Lựa chọn: ");
            if(!int.TryParse(Console.ReadLine()!, out int luachon)){
                Console.WriteLine("Vui lòng chọn hợp lệ !");
                continue;
            }
            Console.WriteLine();
            if(luachon == 1){
                this.danhsachsinhvien.Sort((a, b)
                    => String.Compare(LayTenCuoi(a.TenSinhVien), LayTenCuoi(b.TenSinhVien)));
                Console.WriteLine("Đã sắp xếp theo tên (A->Z)");
            } 
            else if(luachon == 2){
                this.danhsachsinhvien.Sort((a, b)
                    => String.Compare(LayTenCuoi(b.TenSinhVien), LayTenCuoi(a.TenSinhVien)));
                Console.WriteLine("Đã sắp xếp theo tên (Z->A)");
            } 
            else if(luachon == 3){
                this.danhsachsinhvien.Sort((a, b)
                    => (a.DiemSinhVien).CompareTo(b.DiemSinhVien));
                Console.WriteLine("Đã sắp xếp theo điểm (Thấp->Cao)");
            }
            else if(luachon == 4){
                this.danhsachsinhvien.Sort((a, b)
                    => (b.DiemSinhVien).CompareTo(a.DiemSinhVien));
                Console.WriteLine("Đã sắp xếp theo điểm (Cao->Thấp)");
            }
            else if(luachon == 0){
                hiendanhsach = false;
                break;
            }
            else {
                Console.WriteLine("Vui lòng chọn hợp lệ");
                continue;
            }
            this.luudulieudanhsach();
            break;
        }
        if(hiendanhsach){
            this.XuatDanhSach();
        }
    }

    // thống kê 
    public void ThongKeThongTinSinhVien(){
        Console.WriteLine("Thống kê thông tin sinh viên");
        int so_hsg = 0, so_hsk = 0, so_hstb = 0, so_hsy = 0;
        float tongdiem = 0f;
        for(int i = 0; i < this.soluongsinhvien; i++){
            float diemsinhvien = this.danhsachsinhvien[i].DiemSinhVien;
            if(diemsinhvien > 8.5) so_hsg++;
            else if(diemsinhvien > 7.0) so_hsk++;
            else if(diemsinhvien > 5.0) so_hstb++;
            else so_hsy++;
            tongdiem += diemsinhvien;
        }
        float diemtrungbinhlop = tongdiem / this.soluongsinhvien;
        float diemcaonhat = this.danhsachsinhvien.Max(sv => sv.DiemSinhVien);
        float diemthapnhat = this.danhsachsinhvien.Min(sv => sv.DiemSinhVien);

        Console.WriteLine("Sĩ số: {0}", this.soluongsinhvien);
        Console.WriteLine(
            "HSG: {0}\tHSK: {1}\tHSTB: {2}\tHSY: {3}",
            so_hsg, so_hsk, so_hstb, so_hsy
        );
        Console.WriteLine("Điểm trung bình lớp: {0:F1}", diemtrungbinhlop);
        Console.WriteLine(
            "Điểm cao nhất: {0:F1}\tĐiểm thấp nhất: {1:F1}",
            diemcaonhat, diemthapnhat
        );
    }

    // xuất danh sách sinh viên 
    public void XuatDanhSach(){
        Console.WriteLine("Danh sách sinh viên");
        Console.WriteLine("{0,-5} {1,-25} {2,-15} {3,-6}", "STT", "Tên", "Mã số", "Điểm");
        for(int i = 0; i < this.soluongsinhvien; i++){
            this.danhsachsinhvien[i].XuatThongTin(i + 1);
        }
    }
}
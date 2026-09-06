public class QuanLySinhVien {
    public List<SinhVien> danhsachsinhvien = new List<SinhVien>();

    private void tinhstttieptheo(){
        for(int i = 0; i < danhsachsinhvien.Count; i++){
            danhsachsinhvien[i].stt = i + 1;
        }
    }

    public bool kiemtrathongtin(SinhVien sinhvien){
        if(string.IsNullOrWhiteSpace(sinhvien.hoten)
        || string.IsNullOrWhiteSpace(sinhvien.mssv)
        || !sinhvien.diemgpa.HasValue
        || string.IsNullOrWhiteSpace(sinhvien.hocluc)){
            return false;
        }
        return true;
    }

    // tạo các hàm thêm, xóa, sửa, sắp xếp, thống kê, in 
    public void themsinhvien(SinhVien sinhvienmoi){
        if(kiemtrathongtin(sinhvienmoi)){
            danhsachsinhvien.Add(sinhvienmoi);
            Console.WriteLine("Đã thêm sinh viên {0}", sinhvienmoi.hoten);
        }
        else {
            Console.WriteLine("Thêm sinh viên {0}", sinhvienmoi, " không thành công do thông tin nhập lỗi");
        }
    }

    public void suathongtinsinhvien(int stt){
        Console.WriteLine("SỬA THÔNG TIN SINH VIÊN");
        var timthaysinhvien = danhsachsinhvien.Find(sv => sv.stt == stt);
        if(timthaysinhvien == null){
            Console.WriteLine("Không tìm thấy sinh viên có STT {0} !", stt);
            return;
        }
        Console.WriteLine("Đang sửa thông tin của: {0} (MSSV: {1})", timthaysinhvien.hoten, timthaysinhvien.mssv);
        Console.WriteLine("Bỏ trống và nhấn Enter để giữ nguyên giá trị cũ");
        Console.Write("Tên mới [{0}]: ", timthaysinhvien.hoten);
        string ten = Console.ReadLine()!;
        if(!string.IsNullOrWhiteSpace(ten)) timthaysinhvien.hoten = ten;
        Console.Write("MSSV mới [{0}]: ", timthaysinhvien.mssv);
        string mssv = Console.ReadLine()!;
        if(!string.IsNullOrWhiteSpace(mssv)) timthaysinhvien.mssv = mssv;
        Console.WriteLine("Vui lòng nhập điểm có dấu',' thay cho dấu '.'");
        Console.Write("Điểm GPA mới [{0}]: ", timthaysinhvien.diemgpa);
        string gpa = Console.ReadLine()!;
        if(!string.IsNullOrWhiteSpace(gpa)){
            if(float.TryParse(gpa, out float diem)){
                timthaysinhvien.diemgpa = diem;
                timthaysinhvien.hocluc = timthaysinhvien.tinh_hocluc();
                Console.WriteLine("Đã tự cập nhật học lực thành: {0}", timthaysinhvien.hocluc);
            } else {
                Console.WriteLine("Điểm nhập không hợp lệ, giữ nguyên giá trị cũ");
            }
        }
        Console.WriteLine("Đã cập nhật thông tin sinh viên!");
    }

    public void xoasinhvien(int stt){
        Console.WriteLine("XÓA THÔNG TIN SINH VIÊN");
        var timthaysinhvien = danhsachsinhvien.Find(sv => sv.stt == stt);
        if(timthaysinhvien != null){
            danhsachsinhvien.RemoveAt(stt - 1);
            Console.WriteLine("Đã xóa sinh viên {0}", timthaysinhvien.hoten);
        }else {
            Console.WriteLine("Không tìm thấy sinh viên !");
        }
    }

    public void sapxepsinhvien(){
        bool hiendanhsach = true;
        while(true){
            Console.WriteLine(
                "SẮP XẾP SINH VIÊN\n" +
                "1. Sắp xếp theo tên (A -> Z)\n" + 
                "2. Sắp xếp theo tên (Z -> A)\n" + 
                "3. Sắp xếp theo điểm (Thấp -> Cao)\n" + 
                "4. Sắp xếp theo điểm (Cao -> Thấp)\n" + 
                "5. Quay lại"
            );
            Console.Write("Nhập lựa chọn của ban: ");
            int luachon = int.Parse(Console.ReadLine()!);
            if(luachon == 1){
                danhsachsinhvien.Sort((a, b) => string.Compare(a.hoten, b.hoten));
                Console.WriteLine("Đã sắp xếp theo tên (A -> Z)");
            } else if(luachon == 2){
                danhsachsinhvien.Sort((a, b) => string.Compare(b.hoten, a.hoten));
                Console.WriteLine("Đã sắp xếp theo tên (Z -> A)");
            } else if(luachon == 3){
                danhsachsinhvien.Sort((a, b) => (a.diemgpa ?? 0).CompareTo(b.diemgpa ?? 0));
                Console.WriteLine("Đã sắp xếp theo điểm (Thấp -> Cao)");
            } else if(luachon == 4){
                danhsachsinhvien.Sort((a, b) => (b.diemgpa ?? 0).CompareTo(a.diemgpa ?? 0));
                Console.WriteLine("Đã sắp xếp theo điểm (Cao -> Thấp)");
            } else if(luachon == 5){
                break;
            } else {
                hiendanhsach = false;
                Console.WriteLine("Vui lòng chọn hợp lệ !");
                continue;
            }
            break;
        }
        if(hiendanhsach){
            this.inthongtinsinhvien();
        }
    }

    public void thongkesinhvien(){
        int soluongsinhvien = danhsachsinhvien.Count;
        int so_hsg = 0, so_hsk = 0, so_hstb = 0;
        float tyle_hsg = 0f, tyle_hsk = 0f, tyle_hstb = 0f;
        foreach(var sinhvien in danhsachsinhvien){
            if(sinhvien.hocluc == "Gioi") so_hsg++;
            else if(sinhvien.hocluc == "Khá") so_hsk++;
            else so_hstb++;
        }
        if(soluongsinhvien == 0){
            Console.WriteLine("Danh sách sinh viên rỗng !");
            return;
        }
        if(so_hsg == soluongsinhvien) tyle_hsg = 100f;
        else if(so_hsk == soluongsinhvien) tyle_hsk = 100f;
        else if(so_hstb == soluongsinhvien) tyle_hstb = 100f;
        else{
            tyle_hsg = ((float)so_hsg/(float)soluongsinhvien) * 100f;
            tyle_hsk = ((float)so_hsk/(float)soluongsinhvien) * 100f;
            tyle_hstb = 100f - (tyle_hsg + tyle_hsk);
        }
        Console.WriteLine(
            "THỐNG KÊ\n" + 
            "Lớp có:\n" + 
            "{0} học sinh giỏi - tỷ lệ: {3}%\n{1} học sinh khá - tỷ lệ: {4}%\n{2} học sinh trung bình - tỷ lệ: {5}%",
            so_hsg, so_hsk, so_hstb,
            tyle_hsg, tyle_hsk, tyle_hstb
        );
    }

    public void inthongtinsinhvien(){
        Console.WriteLine("DANH SÁCH SINH VIÊN");
        this.tinhstttieptheo();
        if(danhsachsinhvien.Count == 0){
            Console.WriteLine("Danh sách sinh viên rỗng !");
            return;
        }
        Console.WriteLine("{0,-5}{1,-15}{2,-10}{3,-10}{4}",
            "STT", "Tên", "Mssv", "Điểm", "Học lực");
        foreach (var sinhvien in danhsachsinhvien){
            Console.WriteLine("{0,-5}{1,-15}{2,-10}{3,-10}{4}",
                sinhvien.stt,
                sinhvien.hoten,
                sinhvien.mssv,
                sinhvien.diemgpa?.ToString("N2"),
                sinhvien.hocluc
            );
        }
    }

    public void hienthithucdon(){
        Console.WriteLine("MENU");
        Console.WriteLine("[01] In danh sách sinh viên");
        Console.WriteLine("[02] Thêm sinh viên");
        Console.WriteLine("[03] Sửa thông tin sinh viên");
        Console.WriteLine("[04] Xóa sinh viên");
        Console.WriteLine("[05] Sắp xếp sinh viên");
        Console.WriteLine("[06] Thống kê sinh viên");
        Console.WriteLine("[00] Thoát");
    }

    public SinhVien nhapthongtinsinhvien(){
        Console.WriteLine("THÊM THÔNG TIN SINH VIÊN");
        Console.Write("Nhập họ tên: ");
        string hoten = Console.ReadLine()!;
        Console.Write("Nhập mssv: ");
        string mssv = Console.ReadLine()!;
        Console.Write("Nhập điểm gpa: ");
        float diemgpa = float.Parse(Console.ReadLine()!);
        SinhVien sinhvienmoitao = new SinhVien(hoten, mssv, diemgpa);
        return sinhvienmoitao;
    }
}
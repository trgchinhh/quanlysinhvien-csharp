public class SinhVien {
    public int? stt = null;
    public string? hoten = null;
    public string? mssv = null;
    public float? diemgpa = null;
    public string? hocluc = null;

    public SinhVien(){
        hoten = "Không có";
        mssv = "Không có";
        diemgpa = -1f;
        hocluc = "Không có";
    }

    public SinhVien(string hoten, string mssv, float diemgpa){
        this.hoten = hoten;
        this.mssv = mssv;
        this.diemgpa = diemgpa;
        this.hocluc = this.tinh_hocluc();
    }

    public string tinh_hocluc(){
        if(diemgpa >= 8.0) return "Gioi";
        else if(diemgpa <= 8.0 && diemgpa >= 6.5) return "Khá";
        else return "Trung bình";
    }
}
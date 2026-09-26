public class SinhVien {
    // Field

    private string tensinhvien;
    private string masosinhvien;
    private float diemsinhvien;

    // Constructor 

    public SinhVien(){
        this.tensinhvien = "";
        this.masosinhvien = "";
        this.diemsinhvien = 0f;
    }

    public SinhVien(string tensinhvien, string masosinhvien, string lopsinhvien, int diemsinhvien){
        this.tensinhvien = tensinhvien;
        this.masosinhvien = masosinhvien;
        this.diemsinhvien = diemsinhvien;
    }

    // Properties

    public string TenSinhVien {
        get { return this.tensinhvien; }
        set {
            if(!string.IsNullOrEmpty(value)){
                this.tensinhvien = value;
            } else {
                Console.WriteLine("Không được để tên trống !");
            }
        }
    }

    public string MaSoSinhVien {
        get { return this.masosinhvien; }
        set {
            if(!string.IsNullOrEmpty(value)){
                this.masosinhvien = value;
            } else {
                Console.WriteLine("Không được để mã số sinh viên trống !");
            }
        }
    }

    public float DiemSinhVien {
        get { return this.diemsinhvien; }
        set {
            if(value > 0 && value <= 10){
                this.diemsinhvien = value;
            } else {
                Console.WriteLine("Điểm sinh viên trong khoảng 0 -> 10 !");
            }
        }
    }

    // Methods 
    public void NhapThongTin(){
        string ten, maso;
        float diem;
        
        do {
            Console.Write("Nhập tên: ");
            ten = Console.ReadLine()!;
            if(string.IsNullOrEmpty(ten)){
                Console.WriteLine("Không được để tên trống !");
            }
        } while(string.IsNullOrEmpty(ten));
        this.TenSinhVien = ten;

        do {
            Console.Write("Nhập mã số: ");
            maso = Console.ReadLine()!;
            if(string.IsNullOrEmpty(maso)){
                Console.WriteLine("Không được để mã số trống !");
            }
        } while(string.IsNullOrEmpty(maso));
        this.MaSoSinhVien = maso;

        do {
            Console.Write("Nhập điểm: ");
            float.TryParse(Console.ReadLine()!, out diem);
            if(diem <= 0 || diem > 10){
                Console.WriteLine("Điểm phải nằm trong khoảng 1 -> 10");
            }
        } while(diem <= 0 || diem > 10);
        this.DiemSinhVien = diem;
    }

    public void XuatThongTin(int sothutu){
        Console.WriteLine(
            "{0,-5} {1,-25} {2,-15} {3,-6:F1}",
            sothutu,
            this.tensinhvien,
            this.masosinhvien,
            this.diemsinhvien
        );
    }
}
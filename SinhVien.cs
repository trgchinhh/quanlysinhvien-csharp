public class SinhVien : ConNguoi {
    private string mssv = "";
    public SinhVien() : base() {
        mssv = "00000";
    }

    public SinhVien(string hoten, string cccd, string mssv)
    : base(hoten, cccd){
        dat_mssv = mssv;
    }

    public string dat_mssv{
        get { return mssv; }
        set {
            if(string.IsNullOrWhiteSpace(value))
                Console.WriteLine("MSSV không được để trống !");
            else mssv = value;
        }
    }

    public void inthongtinsv(){
        base.inthongtin();
        Console.WriteLine("MSSV: " + mssv + "\n");
    }
}
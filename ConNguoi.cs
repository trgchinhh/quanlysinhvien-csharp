public class ConNguoi {
    public string hoten = "";
    private string cccd = "";

    // constructor - hàm xây 
    public ConNguoi(){
        hoten = "Chưa có";
        cccd = "00000";
    }

    public ConNguoi(string hoten, string cccd){
        dat_hoten = hoten;
        dat_cccd = cccd;
    }

    // set - get (gán và lấy giá trị thông qua điều kiện gì đó)
    public string dat_hoten {
        get { return hoten; }
        set {
            if(string.IsNullOrWhiteSpace(value))
                Console.WriteLine("Không được để tên trống !");
            else hoten = value;
        }
    }

    public string dat_cccd {
        get { return cccd; }
        set {
            if(string.IsNullOrWhiteSpace(value))
                Console.WriteLine("Không được để CCCD trống !");
            else if(value.Length < 5)
                Console.WriteLine("Chiều dài CCCD không bé hơn 5");
            else cccd = value;
        }
    }

    public void inthongtin(){
        string str_hoten = "", str_cccd = "";
        if(string.IsNullOrWhiteSpace(hoten)) str_hoten = "Chưa có";
        else str_hoten = hoten;
        if(string.IsNullOrWhiteSpace(cccd)) str_cccd = "Chưa có";
        else str_cccd = cccd;
        Console.WriteLine(
            "Tên: " + str_hoten + 
            "\nCCCD: " + str_cccd
        );  
    }
}
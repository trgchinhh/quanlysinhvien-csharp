public class Program {
    public static void Main(){

        ConNguoi nguoithu1 = new ConNguoi();
        nguoithu1.hoten = "Truong Chinh";
        nguoithu1.dat_cccd = "1"; 
        nguoithu1.inthongtin();

        ConNguoi nguoithu2 = new ConNguoi();
        nguoithu2.inthongtin();

        ConNguoi nguoithu3 = new ConNguoi("Chinh", "");
        nguoithu3.inthongtin();

        SinhVien sinhvien1 = new SinhVien();
        sinhvien1.inthongtinsv();

        SinhVien sinhvien2 = new SinhVien("Truong Chinh", "11111", "22222");
        sinhvien2.inthongtinsv();

    }
}

public class Program {
    public static void dungchuongtrinh(){
        Console.Write("\nNhấn enter để tiếp tục...");
        Console.ReadKey();
    }

    public static void Main(){
        QuanLySinhVien quanlysinhvien = new QuanLySinhVien();

        // tạo db sẵn 
        quanlysinhvien.themsinhvien(new SinhVien("Chinh", "001", 9.5f));
        quanlysinhvien.themsinhvien(new SinhVien("Phuc", "002", 8.5f));
        quanlysinhvien.themsinhvien(new SinhVien("Bao", "003", 8.0f));
        // in lần đầu cho đánh stt
        quanlysinhvien.inthongtinsinhvien();

        while(true){
            Console.Clear();
            quanlysinhvien.hienthithucdon();
            Console.Write("[?] Lựa chọn: ");
            if(!int.TryParse(Console.ReadLine(), out int luachon)){
                Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập số");
                continue;
            }

            Console.WriteLine("");
            if(luachon == 0){
                Console.WriteLine("Hẹn gặp lại !");
                break;
            } 
            else if(luachon == 1){
                quanlysinhvien.inthongtinsinhvien();
            }
            else if(luachon == 2){
                quanlysinhvien.themsinhvien(quanlysinhvien.nhapthongtinsinhvien());
            }
            else if(luachon == 3){
                quanlysinhvien.inthongtinsinhvien();
                Console.Write("Nhập STT sinh viên cần sửa: ");
                if(int.TryParse(Console.ReadLine(), out int sttsua)){
                    quanlysinhvien.suathongtinsinhvien(sttsua);
                }
            }
            else if(luachon == 4){
                quanlysinhvien.inthongtinsinhvien();
                Console.Write("Nhập STT sinh viên cần xóa: ");
                if(int.TryParse(Console.ReadLine(), out int sttxoa)){
                    quanlysinhvien.xoasinhvien(sttxoa);
                }
            }
            else if(luachon == 5){
                quanlysinhvien.sapxepsinhvien();
            }
            else if(luachon == 6){
                quanlysinhvien.thongkesinhvien();
            }
            else {
                Console.WriteLine("Lựa chọn không hợp lệ");
            }
            dungchuongtrinh();
        }
    }
}
